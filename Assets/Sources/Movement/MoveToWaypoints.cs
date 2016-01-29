using UnityEngine;
using System.Collections;

public class MoveToWaypoints : MonoBehaviour 
{
	[SerializeField]
	private Transform[] m_Waypoints;

	[SerializeField]
	private NavMeshAgent m_NavMeshAgent;

	private int m_CurrentWaypoint;

	private void Start()
	{
		//move to first waypoint
		MoveToWaypoint(1);
	}

	private void Update()
	{
		//if path finished move to next waypoint
		if (m_NavMeshAgent.remainingDistance == 0)
		{
			MoveNext();	
		}
	}

	private void MoveNext()
	{
		m_CurrentWaypoint = (m_CurrentWaypoint + 1) % m_Waypoints.Length;
		MoveToWaypoint(m_CurrentWaypoint);
	}

	private void MoveToWaypoint(int index)
	{
		m_NavMeshAgent.destination = m_Waypoints[index].localPosition;
		m_CurrentWaypoint = index;
	}
}
