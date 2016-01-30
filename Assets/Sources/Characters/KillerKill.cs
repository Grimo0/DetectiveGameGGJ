using UnityEngine;
using System.Collections;

public class KillerKill : MonoBehaviour {

    Transform targetCharacter;

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
            StartCoroutine(DestroyNPC(targetCharacter.parent.gameObject));
        }
    }

    IEnumerator DestroyNPC(GameObject npc)
    {
        yield return new WaitForSeconds(3f);
        Destroy(npc);
		GameObject.Find("GameManager").GetComponent<NPCs>().npcs.Remove(npc.GetComponent<Appearance>());

		KillerBehavior killerBehavior = GameObject.Find("GameManager").GetComponent<KillerBehavior>();
		if (killerBehavior.Kill(npc.GetComponent<NPC>()))
        {
			Debug.Log("mission "+ killerBehavior.RitualNumber + " achieved");
        }
        else
            Debug.Log("wrong NPC");
    }
}
