using UnityEngine;
using System.Collections;

public class FadeSound : MonoBehaviour 
{
	[SerializeField]
	private float m_Duration;

	[SerializeField]
	private float m_Volume;

	[SerializeField]
	private AudioSource[] m_Sources;

	private float m_Fade;

	void Update() 
	{
		m_Fade = Mathf.Min(1, m_Fade + (m_Volume/m_Duration) * Time.deltaTime);

		m_Sources[0].volume = Mathf.Lerp(0, m_Volume, 1 - m_Fade);
		m_Sources[1].volume = Mathf.Lerp(0, m_Volume, m_Fade);

		if (m_Fade == 1)
		{
			enabled = false;
		}
	}

	public void PlayFade(AudioClip fromClip, AudioClip toClip)
	{
		AudioSource source = m_Sources[0];
		source.clip   = fromClip;
		source.volume = m_Volume;

		source.Play();

		source = m_Sources[1];
		source.clip   = toClip;
		source.volume = 0f;

		source.Play();

		enabled = true;
		m_Fade  = 0f;
	}

	public void Stop()
	{
		PlayFade(m_Sources[1].clip, null);
	}
}
