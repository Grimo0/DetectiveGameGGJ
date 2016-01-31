using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour 
{
	[SerializeField]
	private float m_DistributionRatio;

	[SerializeField]
	private float[] m_BehaviourProbabilities;

	[SerializeField]
	private NPCBehaviour[] m_NPCBehaviours;

    //called from NPCBehaviour OnCompleted callback
    public void StartBehaviour()
	{
		int randomBehaviourIndex = PickBehaviour();
		m_NPCBehaviours[randomBehaviourIndex].Move();

		Redistribute(randomBehaviourIndex);
	}

	public T FindBehaviour<T>() where T : NPCBehaviour
	{
		for (int i = 0; i < m_NPCBehaviours.Length; i++)
		{
			T currentBehaviour = m_NPCBehaviours[i] as T;
			if (currentBehaviour != null)
			{
				return currentBehaviour;
			}
		}

		return null;
	}

	public MoveToTarget GetMoveToTarget()
	{
		//quickly get a move to target script and assing target (if any)
		return GetComponent<MoveToTarget>();
	}

	public MoveToWaypoints GetMoveToWaypoints()
	{
		return GetComponent<MoveToWaypoints>();	
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

	private void Redistribute(int index)
	{
		//penalize picked behaviour and distribute equally a certain ratio of probability
		float value = m_BehaviourProbabilities[index] * m_DistributionRatio;
		m_BehaviourProbabilities[index] -= value;

		int count = m_BehaviourProbabilities.Length - 1;
		value /= count;

		for (int i = 0; i < m_BehaviourProbabilities.Length; i++)
		{
			if (i != index)
			{
				m_BehaviourProbabilities[index] += value;
			}
		}
	}
}
