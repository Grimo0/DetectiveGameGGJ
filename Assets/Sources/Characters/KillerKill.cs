using UnityEngine;
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
            
            Invoke("Laugth", 3f);
            GameObject.Find("KillerUI").GetComponent<KillerUI>().DoPentacleAnim();

            targetCharacter.GetComponentInParent<Appearance>().DoDeathAnim();
        }
    }

    void Laugth()
    {
		Source.PlayOneShot(BruitageCri[Random.Range(0,BruitageCri.Length)]);
    }
}
