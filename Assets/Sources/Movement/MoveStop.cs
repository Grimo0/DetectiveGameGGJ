using UnityEngine;
using System.Collections;

public class MoveStop : NPCBehaviour 
{
	[SerializeField]
	private float m_Delay;

	public override void Move()
	{
		//wait at current destination until delay
		m_NavMeshAgent.destination = transform.position;

		Invoke("Completed", m_Delay);
	}

	public override void Refresh()
	{
		Move();
	}

	private void Completed()
	{
		OnCompleted.Invoke();
	}
}
