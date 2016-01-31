using UnityEngine;

using System.Collections;
using System.Collections.Generic;

[RequireComponent( typeof(NavMeshObstacle) )]
public class Door : MonoBehaviour
{
	public AudioClip Locked;
	public AudioSource Source;

	[SerializeField]
	protected int m_Delay;

	[SerializeField]
	private TextMesh m_Text;

	[SerializeField]
	protected Animator m_Animator;

	private List<NPCBehaviour> m_NPCBehaviours = new List<NPCBehaviour>();

	private NavMeshObstacle m_NavMeshObstacle;

	private int m_CooldownCounter;

	protected Coroutine m_CooldownCoroutine;

	private void Awake()
	{
		m_NavMeshObstacle = GetComponent<NavMeshObstacle>();	
	}

	protected bool m_IsClosed;

	public void AddAgent(GameObject npc)
	{
		NPCBehaviour[] behaviours = npc.GetComponents<NPCBehaviour>();
		m_NPCBehaviours.AddRange(behaviours);
	}

	public virtual void Close()
	{
		if (m_IsClosed)
		{
			return;
		}
		Source.PlayOneShot (Locked);
		CloseNoCoroutine();

		//open in 5 seconds
		if (m_CooldownCoroutine != null)
		{
			StopCoroutine(m_CooldownCoroutine);
		}

		m_CooldownCoroutine = StartCoroutine(Countdown());
	}

	public virtual void CloseNoCoroutine()
	{
		EnableObstacle(true);
		UpdateAgents();

		m_Animator.SetTrigger(@"Close");

		m_IsClosed = true;
	}

	public void Hover()
	{
		if (!m_IsClosed)
		{
			m_Animator.SetBool(@"Hover", true);	
		}
	}

	public void HoverOut()
	{
		m_Animator.SetBool(@"Hover", false);
	}

	public void UpdateAgents()
	{
		for (int i = 0; i < m_NPCBehaviours.Count; i++)
		{
			m_NPCBehaviours[i].Refresh();
		}
	}

	private void EnableObstacle(bool isEnabled)
	{
		m_NavMeshObstacle.carving = isEnabled;
		m_NavMeshObstacle.enabled = isEnabled;
	}

	public virtual void Open()
	{
		m_IsClosed = false;

		EnableObstacle(false);
		UpdateAgents();

		m_Animator.SetTrigger(@"Open");
	}

	protected IEnumerator Countdown()
	{
		m_CooldownCounter = m_Delay;
		while (m_CooldownCounter > 0)
		{
			m_Text.text = m_CooldownCounter.ToString();
			m_CooldownCounter--;

			yield return new WaitForSeconds(1f);
		}

		//reset text
		m_Text.text = @"";

		Open();
	}
}
