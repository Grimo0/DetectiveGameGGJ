using UnityEngine;
using System.Collections.Generic;

[RequireComponent( typeof(NavMeshObstacle) )]
public class Door : MonoBehaviour 
{
	public bool m_Open;
	public bool m_Close;

	private List<NPCBehaviour> m_NPCBehaviours = new List<NPCBehaviour>();

	private NavMeshObstacle m_NavMeshObstacle;

	private void Awake()
	{
		m_NavMeshObstacle = GetComponent<NavMeshObstacle>();	
	}

	private void Update()
	{
		if (m_Open)
		{
			Open();
			m_Open = false;
		}

		if (m_Close)
		{
			Close();
			m_Open = false;
		}
	}

	public void AddAgent(GameObject npc)
	{
		NPCBehaviour[] behaviours = npc.GetComponents<NPCBehaviour>();
		m_NPCBehaviours.AddRange(behaviours);
	}

	public void Open()
	{
		m_NavMeshObstacle.carving = false;
		UpdateAgents();
	}

	public void Close()
	{
		m_NavMeshObstacle.carving = true;
		UpdateAgents();
	}

	public void UpdateAgents()
	{
		for (int i = 0; i < m_NPCBehaviours.Count; i++)
		{
			m_NPCBehaviours[i].Refresh();
		}
	}
}
