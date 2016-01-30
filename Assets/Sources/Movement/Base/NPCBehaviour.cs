using UnityEngine;
using UnityEngine.Events;

using System.Collections;

[RequireComponent( typeof(NavMeshAgent) )]
public abstract class NPCBehaviour : MonoBehaviour 
{
	[SerializeField]
	private float m_MinDistanceToTarget;

	[SerializeField]
	protected UnityEvent OnInitialized;

	[SerializeField]
	protected UnityEvent OnCompleted;

	protected bool m_IsStarted;

	protected NavMeshAgent m_NavMeshAgent;

	private void Awake()
	{		
		m_NavMeshAgent = GetComponent<NavMeshAgent>();

		OnInitialized.Invoke();
	}

	protected virtual void Update()
	{		
		if (m_IsStarted && m_NavMeshAgent.remainingDistance <= m_MinDistanceToTarget)
		{
			m_IsStarted = false;

			OnCompleted.Invoke();
		}
	}

	public abstract void Move();
	public abstract void Refresh();
}
