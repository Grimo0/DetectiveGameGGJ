﻿using UnityEngine;
using System.Collections;

public class MoveToTarget : NPCBehaviour 
{
	[SerializeField]
	private Transform m_Target;

	private KillerBehavior m_KillerBehaviour;
	private Level          m_Level;

	public void Init(KillerBehavior killerBehaviour, Level level)
	{
		m_KillerBehaviour = killerBehaviour;
		m_Level           = level;
	}

	protected override void Update()
	{
		if (m_IsStarted)
		{
			//follow target in case it changes position
			m_NavMeshAgent.destination = m_Target.position;
		}

		base.Update();
	}

	public override void Move()
	{
		m_Target = FindKillerTarget();

		m_NavMeshAgent.destination = m_Target.position;
		m_IsStarted = true;
	}

	public override void Refresh()
	{
		Move();
	}

	private Transform FindKillerTarget()
	{
		Transform result = null;

		NPC npc;

		bool found = false;
		do
		{
			Transform randomTarget = m_Level.GetRandomTarget();
			npc = randomTarget.GetComponent<NPC>();

			found = m_KillerBehaviour.IsTarget(npc);
		}
		while(!found);

		if (found)
		{
			result = npc.transform;
		}

		return result;
	}
}
