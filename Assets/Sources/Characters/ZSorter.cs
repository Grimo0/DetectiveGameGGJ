using UnityEngine;
using System.Collections;

public class ZSorter : MonoBehaviour 
{
	[SerializeField]
	private SpriteRenderer[] m_SpriteRenderers;

	private int[] defaultOrder;
	private void Start()
	{
		defaultOrder = new int[m_SpriteRenderers.Length];
		for (int i = 0; i < defaultOrder.Length; i++)
		{
			defaultOrder[i] = m_SpriteRenderers[i].sortingOrder;
		}
	}

	private void Update() 
	{
		//set order in layer based on Z value (lower is better)
		for (int i = 0; i < m_SpriteRenderers.Length; i++)
		{
			m_SpriteRenderers[i].sortingOrder = defaultOrder[i] + (int) (100 - transform.position.z);
		}
	}
}
