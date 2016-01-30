using UnityEngine;
using System.Collections;

public class MoveToTarget : NPCBehaviour 
{
	[SerializeField]
	private Transform m_Target;

	protected override void Update()
	{
		if (m_IsStarted)
		{
			//follow target in case it changes position
			m_NavMeshAgent.destination = m_Target.position;
		}

		base.Update();
	}

	public void AddTarget(Transform target)
	{
		m_Target = target;
	}

	public override void Move()
	{
		m_NavMeshAgent.destination = m_Target.position;
		m_IsStarted = true;
	}

	public override void Refresh()
	{
		Move();
	}
}
