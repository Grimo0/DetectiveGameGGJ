using UnityEngine;
using System.Collections;

public class DetectiveInput : MonoBehaviour 
{
	[SerializeField]
	private string m_ShootInput;

	[SerializeField]
	private Detective m_Detective;

	private void Update()
	{
		if (Input.GetButtonDown(m_ShootInput))
		{
			//toggle shoot mode
			m_Detective.ShootMode = !m_Detective.ShootMode;
		}
	}
}
