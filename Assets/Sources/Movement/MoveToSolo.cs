using UnityEngine;
using System.Collections;

//go to a solo point and wait for delay
public class MoveToSolo : NPCBehaviour 
{
	[SerializeField]
	private MoveToTarget m_MoveToTarget;

	[SerializeField]
	private MoveStop m_Stop;

	private Level m_Level;

	public void Init(Level level)
	{
		m_Level = level;
	}
		
	public void Stop()
	{
		m_Stop.Move();
	}

	public override void Move()
	{
		m_MoveToTarget.SetTarget(m_Level.GetRandomSolo());
		m_MoveToTarget.GoToTarget();
	}

	public override void Refresh ()
	{
		Move();
	}

}
