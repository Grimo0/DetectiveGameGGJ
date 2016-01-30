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
        if(Input.GetButtonDown("Fire2") && targetCharacter != null)
        {
            Debug.Log("killer has killed " + targetCharacter.name);
            Destroy(targetCharacter.parent.gameObject);
        }
    }
}
