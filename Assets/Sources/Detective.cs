using UnityEngine;
using System.Collections;

public class Detective : MonoBehaviour {
    
	public LayerMask doorLayer;
	public LayerMask shootLayer;

	public AudioClip Shoot;
	public AudioClip ReloadGun;
	public AudioClip[] BruitageCri;

	public AudioSource Source;

    private bool shootMode;
    public bool ShootMode
    {
        set
        {
            shootMode = value;

            if (shootMode)
            {
                Cursor.SetCursor(cursorTarget, Vector2.one * 16f, CursorMode.Auto);
				Source.PlayOneShot (ReloadGun);
            }
            else
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        get { return shootMode;  }
    }

    private CharacterMouseOver targetCharacter;
	private Door               targetDoor;

    RaycastHit hit;

    Texture2D cursorTarget;

    void Start()
    {
        cursorTarget = Resources.Load<Texture2D>("Sprites/cursorTarget");
    }

	void Update()
    {
		LayerMask layer = ShootMode ? shootLayer : doorLayer;
		bool isHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layer); 

		if (ShootMode)
        {
			if (isHit)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.transform.tag == "SelectionCollider")
                    {
                        if (targetCharacter != null)
                        {
                            if (targetCharacter != hit.transform)
                                targetCharacter.IsSelected = false;
                        }

                        targetCharacter = hit.collider.GetComponent<CharacterMouseOver>();
                        targetCharacter.IsSelected = true;
                    }
                    else if (targetCharacter != null)
                    {
                        targetCharacter.IsSelected = false;
                        targetCharacter = null;
                    }
                }
                else if(targetCharacter != null)
                {
                    targetCharacter.IsSelected = false;
                    targetCharacter = null;
                }
            }
            else if (targetCharacter != null)
            {
                targetCharacter.IsSelected = false;
                targetCharacter = null;
            }
				
            if (Input.GetButtonDown("Left_Click") && targetCharacter != null)
            {
				Debug.Log("Play shoot");
				Source.PlayOneShot(Shoot);
				Source.PlayOneShot(BruitageCri[Random.Range(0,BruitageCri.Length)]);

                if (targetCharacter.transform.parent.tag == "Player")
                    GetComponent<EndGame>().DetectiveWins();
                else
                    GetComponent<EndGame>().WrongKillerKilled();

				enabled = false;
            }
        }
		else
		{
			if (isHit)
			{
				if (hit.collider.tag == "DoorCollider")
				{
					//find door
					targetDoor = hit.collider.GetComponent<Door>();
					targetDoor.Hover();
				}
			}
			else
			{
				if (targetDoor != null)
				{
					targetDoor.HoverOut();
				}

				targetDoor = null;
			}

			if (Input.GetButtonDown("Left_Click") && targetDoor != null)
			{
				targetDoor.Close();
			}

		}
	}
}
