using UnityEngine;
using System.Collections;

public class MoveToTarget : NPCBehaviour 
{
	[SerializeField]
	private float m_Delay;

	[SerializeField]
	private Transform m_Target;

	private KillerBehavior m_KillerBehaviour;
	private Level          m_Level;

	private float m_DelayCounter;

	public void Init(KillerBehavior killerBehaviour, Level level)
	{
		m_KillerBehaviour = killerBehaviour;
		m_Level           = level;
	}

	protected override void Update()
	{
		if (m_IsStarted)
		{
			if (Time.time - m_DelayCounter > m_Delay)
			{
				m_IsStarted = false;
				OnCompleted.Invoke();

				return;
			}

			if (m_Target != null)
			{
				//follow target in case it changes position
				m_NavMeshAgent.destination = m_Target.position;
			}
			else
			{
				//target KILLED
				m_NavMeshAgent.destination = transform.position;
			}
		}

		base.Update();
	}

	public void SetTarget(Transform target)
	{
		m_Target = target;
	}

	public void GoToTarget()
	{
		m_NavMeshAgent.destination = m_Target.position;
		m_IsStarted = true;

		m_DelayCounter = Time.time;
	}

	public override void Move()
	{
		m_Target = FindKillerTarget();

		GoToTarget();
	}

	public override void Refresh()
	{
		Move();
	}

	private Transform FindKillerTarget()
	{
		Transform result = transform;

		NPC npc = null;

		//try 50 times then just go away
		int iter = 0, max = 50;

		bool found = false;
		do
		{
			Transform randomTarget = m_Level.GetRandomTarget();
			if (randomTarget != null)
			{
				npc   = randomTarget.GetComponent<NPC>();
				found = m_KillerBehaviour.IsTarget(npc);
			}

			iter++;
		}
		while(!found && iter < max);

		if (found)
		{
			result = npc.transform;
		}

		return result;
	}
}
