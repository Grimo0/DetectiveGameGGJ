using UnityEngine;
using System.Collections;

public class ZSorter : MonoBehaviour 
{
	[SerializeField]
	private SpriteRenderer[] m_SpriteRenderers;

	void Update() 
	{
		//set order in layer based on Z value (lower is better)
		for (int i = 0; i < m_SpriteRenderers.Length; i++)
		{
			m_SpriteRenderers[i].sortingOrder = (int) (100 - transform.position.z);
		}
	}
}
