﻿using UnityEngine;
using System.Collections;

public class KillerKill : MonoBehaviour {

    Transform targetCharacter;
	public AudioClip[] BruitageCri;
	public AudioSource Source;

	private IEnumerator DestroyCoroutine;

	void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "SelectionCollider")
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

    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "SelectionCollider")
        {
            if (targetCharacter == obj.transform)
            {
                targetCharacter = null;
            }
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Controller_Action") && targetCharacter != null)
        {
            Debug.Log("killer has killed " + targetCharacter.name);
            
			if (DestroyCoroutine == null) 
			{
				DestroyCoroutine = DestroyNPC (targetCharacter.parent.gameObject);
				StartCoroutine (DestroyCoroutine);
			}
        }
    }

    IEnumerator DestroyNPC(GameObject npc)
    {
        yield return new WaitForSeconds(3f);
		Source.PlayOneShot(BruitageCri[Random.Range(0,BruitageCri.Length)]);
        Destroy(npc);

        int isATarget = GameObject.Find("GameManager").GetComponent<KillerBehavior>().IsATarget(npc.GetComponent<NPC>());

        if (isATarget >= 0)
        {
            GameObject.Find("KillerUI").GetComponent<KillerUI>().EndMission(isATarget);
            Debug.Log("mission "+ isATarget + " achieved");
        }
        else
            Debug.Log("wrong NPC");

		DestroyCoroutine = null;
    }
}
