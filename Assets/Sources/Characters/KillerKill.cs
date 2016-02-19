using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillerKill : MonoBehaviour {

    private Transform targetCharacter;
	public AudioClip[] screams;
	public AudioSource source;

	private FadeSound fadeSound;

	private IEnumerator DestroyCoroutine;


	public void Start()
	{
		fadeSound = FindObjectOfType<FadeSound>();
	}
		
	public void OnTriggerStay(Collider obj)
    {
        if(obj.tag == "SelectionCollider" && obj.transform != targetCharacter)
        {
            if (targetCharacter != null)
            {
                if (Vector3.Distance(transform.position, targetCharacter.position) > Vector3.Distance(transform.position, obj.transform.position))
                {
                    targetCharacter = obj.transform;
                }
            }
            else
                targetCharacter = obj.transform;
        }
    }

	public void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "SelectionCollider")
        {
            if (targetCharacter == obj.transform)
            {
                targetCharacter = null;
            }
        }
    }

	public void Update()
    {
        if(Input.GetButtonDown("Controller_Action") && targetCharacter != null)
        {
            Debug.Log("killer has killed " + targetCharacter.name);
            
            Invoke("Scream", 3f);
            GameObject.Find("KillerUI").GetComponent<KillerUI>().DoPentacleAnim();

            targetCharacter.GetComponentInParent<Appearance>().DoDeathAnim();

            targetCharacter = null;

			fadeSound.StopWithDelay();
        }
    }

	public void Scream()
    {
		source.PlayOneShot(screams[Random.Range(0,screams.Length)]);
    }
}
