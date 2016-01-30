using UnityEngine;
using System.Collections.Generic;

[RequireComponent( typeof(NavMeshObstacle) )]
public class Door : MonoBehaviour 
{
	[SerializeField]
	private Animator m_Animator;

	private List<NPCBehaviour> m_NPCBehaviours = new List<NPCBehaviour>();

	private NavMeshObstacle m_NavMeshObstacle;


	private void Awake()
	{
		m_NavMeshObstacle = GetComponent<NavMeshObstacle>();	
	}

	private bool m_IsClosed;

	public void AddAgent(GameObject npc)
	{
		NPCBehaviour[] behaviours = npc.GetComponents<NPCBehaviour>();
		m_NPCBehaviours.AddRange(behaviours);
	}

	public void Toggle()
	{
		m_IsClosed = !m_IsClosed;
		if (m_IsClosed)
		{
			Close();
		}
		else
		{
			Open();
		}
	}

	public void UpdateAgents()
	{
		for (int i = 0; i < m_NPCBehaviours.Count; i++)
		{
			m_NPCBehaviours[i].Refresh();
		}
	}

	private void EnableObstacle(bool isEnabled)
	{
		m_NavMeshObstacle.carving = isEnabled;
		m_NavMeshObstacle.enabled = isEnabled;
	}

	private void Open()
	{
		EnableObstacle(false);
		UpdateAgents();

		m_Animator.SetTrigger(@"Open");
	}
	
	private void Close()
	{
		EnableObstacle(true);
		UpdateAgents();

		m_Animator.SetTrigger(@"Close");
	}
}
