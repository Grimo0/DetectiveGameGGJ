using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour 
{
	[SerializeField]
	private float[] m_BehaviourProbabilities;

	[SerializeField]
	private NPCBehaviour[] m_NPCBehaviours;

	private void Start()
	{
		StartBehaviour();
	}

	//called from NPCBehaviour OnCompleted callback
	public void StartBehaviour()
	{
		int randomBehaviourIndex = PickBehaviour();
		m_NPCBehaviours[randomBehaviourIndex].Move();
	}

	private int PickBehaviour()
	{
		float chance = Random.value;

		float sum = 0f;
		for (int i = 0; i < m_BehaviourProbabilities.Length; i++)
		{
			sum += m_BehaviourProbabilities[i];
			if (sum >= chance)
			{
				return i;
			}
		}

		return m_BehaviourProbabilities.Length - 1;
	}
}
