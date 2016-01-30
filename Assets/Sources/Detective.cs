using UnityEngine;
using System.Collections;

public class Detective : MonoBehaviour {
    
	public LayerMask layer;

    private bool shootMode;
    public bool ShootMode
    {
        set
        {
            shootMode = value;

            if (shootMode)
            {
                Cursor.SetCursor(cursorTarget, Vector2.one * 16f, CursorMode.Auto);
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

            if (Input.GetMouseButtonDown(0) && targetCharacter != null)
            {
                if (targetCharacter.transform.parent.tag == "Player")
                    Debug.Log("You killed the killer");
                else
                    Debug.Log("You lose");
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
				}
			}
			else
			{
				targetDoor = null;
			}

			if (Input.GetMouseButtonDown(0) && targetDoor != null)
			{
				targetDoor.Toggle();
			}

		}
	}
}
