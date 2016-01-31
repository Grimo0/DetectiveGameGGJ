using UnityEngine;
using System.Collections;

public class KillerInput : MonoBehaviour 
{
	[SerializeField]
	private float boostSpeed;

	[SerializeField]
	private string boost;

	private Rigidbody rb;
	private NavMeshAgent navMeshAgent;

	private float speed = 1f;

	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (velocity.magnitude > 1)
            velocity.Normalize();

		if (Input.GetButtonDown(boost))
		{
			speed = boostSpeed;
		}

		if (Input.GetButtonUp(boost))
		{
			speed = 1f;
        }

        rb.velocity = velocity * speed * 4f;
    }
}
