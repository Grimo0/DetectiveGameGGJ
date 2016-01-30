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
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical")).normalized * speed * 4f;

		if (Input.GetButtonDown(boost))
		{
			speed = boostSpeed;
		}

		if (Input.GetButtonUp(boost))
		{
			speed = 1f;
		}
	}
}
