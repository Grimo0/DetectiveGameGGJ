using UnityEngine;
using System.Collections;

public class SpeedBoost : MonoBehaviour 
{
	[SerializeField]
	private float m_Frequency;

	[SerializeField]
	private float m_Probability;

	[SerializeField]
	private float m_Boost;

	private NavMeshAgent m_NavMeshAgent;

	//avoids getting boost twice
	private bool m_HadBoost;

	private float m_DefaultSpeed;

	private void Start()
	{
		m_NavMeshAgent = GetComponent<NavMeshAgent>();
		m_DefaultSpeed = m_NavMeshAgent.speed;

		StartCoroutine(CheckBoost());
	}

	private IEnumerator CheckBoost()
	{
		while (true)
		{
			yield return new WaitForSeconds(m_Frequency);

			float chance = Random.value;
			if (!m_HadBoost && chance < m_Probability)
			{
				m_NavMeshAgent.speed *= m_Boost;
				m_HadBoost = true;
			}
			else
			{
				m_HadBoost = false;
				m_NavMeshAgent.speed = m_DefaultSpeed;
			}
		}
	}
}
