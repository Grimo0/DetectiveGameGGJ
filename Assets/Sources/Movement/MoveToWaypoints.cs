using UnityEngine;
using UnityEngine.Events;

using System.Collections.Generic;

public class MoveToWaypoints : NPCBehaviour 
{
	[SerializeField]
	private float m_Delay;

	[SerializeField]
	private Transform[] m_Waypoints;

	[SerializeField]
	private UnityEvent OnPathFinished;

	private int m_CurrentWaypoint;

	private float m_DelayCounter;

	public void AddWaypoints(Transform[] waypoints)
	{
		m_Waypoints = waypoints;				
	}

	public void CheckFinished()
	{
		if (m_CurrentWaypoint == m_Waypoints.Length - 1)
		{
			OnPathFinished.Invoke();
		}
		else
		{
			Move();
		}
	}

	protected override void Update()
	{		
		if (m_IsStarted && Time.time - m_DelayCounter > m_Delay)
		{
			m_IsStarted = false;

			OnPathFinished.Invoke();
		}
		else
		{
			base.Update();
		}
	}

	public override void Move()
	{
		m_CurrentWaypoint = (m_CurrentWaypoint + 1) % m_Waypoints.Length;
		MoveToWaypoint(m_CurrentWaypoint);

		m_IsStarted = true;

		m_DelayCounter = Time.time;
	}

	public override void Refresh()
	{
		MoveToWaypoint(m_CurrentWaypoint);
	}

	private void MoveToWaypoint(int index)
	{
		m_NavMeshAgent.destination = m_Waypoints[index].position;
		m_CurrentWaypoint = index;
	}

}
