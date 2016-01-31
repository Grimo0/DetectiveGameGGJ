using UnityEngine;
using System.Collections;

public class DoubleDoor : Door 
{
	[SerializeField]
	private Door[] m_Doors;

	public override void Close()
	{
		m_IsClosed = true;
		for (int i = 0; i < m_Doors.Length; i++)
		{
			m_Doors[i].CloseNoCoroutine();
		}

		//open in 5 seconds
		if (m_CooldownCoroutine != null)
		{
			StopCoroutine(m_CooldownCoroutine);
		}

		m_CooldownCoroutine = StartCoroutine(Countdown());

		m_Animator.SetTrigger(@"Close");

		Source.PlayOneShot(Locked);
	}

	public override void Open()
	{
		m_IsClosed = false;

		for (int i = 0; i < m_Doors.Length; i++)
		{
			m_Doors[i].Open();
		}

		m_Animator.SetTrigger(@"Open");
	}
}
