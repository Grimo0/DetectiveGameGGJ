using UnityEngine;
using System.Collections;

public class MoveToNewWaypoints : NPCBehaviour 
{
	[SerializeField]
	private MoveToWaypoints m_MoveToWaypoints;

	private Level m_Level;

	public void Init(Level level)
	{
		m_Level = level;	
	}
			
	public override void Move() 
	{
		SetNewWaypoints();	
		m_MoveToWaypoints.Move();
	}

	public override void Refresh() 
	{
		Move();	
	}

	private void SetNewWaypoints()
	{
		m_Level.SetRandomPath(m_MoveToWaypoints);
	}
}
