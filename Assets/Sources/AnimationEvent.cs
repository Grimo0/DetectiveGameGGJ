using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour 
{
	[SerializeField]
	private AudioClip m_CukooClip;

	[SerializeField]
	private AudioSource m_Source;

	[SerializeField]
	private GameStart m_GameStart;


	public void PlayKukoo()
	{
		m_Source.PlayOneShot(m_CukooClip);	
	}

	public void StartGame()
	{
		m_GameStart.StartGame();
	}

}
