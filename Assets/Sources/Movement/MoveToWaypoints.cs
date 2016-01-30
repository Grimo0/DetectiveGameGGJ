using UnityEngine;
using System.Collections;

public class MoveToWaypoints : NPCBehaviour 
{
	[SerializeField]
	private Transform[] m_Waypoints;

	private int m_CurrentWaypoint;

	public override void Move()
	{
		m_CurrentWaypoint = (m_CurrentWaypoint + 1) % m_Waypoints.Length;
		MoveToWaypoint(m_CurrentWaypoint);

		m_IsStarted = true;
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
