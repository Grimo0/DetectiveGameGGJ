using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Path
{
	public string Name;

	public Transform[] Waypoints;
}

public class Level : MonoBehaviour 
{
	[SerializeField]
	private List<Path> m_Paths;

	[SerializeField]
	private List<Transform> m_Characters;

	public void AddCharacter(Transform character)
	{
		m_Characters.Add(character);
	}
		
	public void SetRandomPath(MoveToWaypoints npcMoveToWaypoints)
	{		
		Path path = m_Paths[Random.Range(0, m_Paths.Count)];
		npcMoveToWaypoints.AddWaypoints(path.Waypoints);
	}

	public void SetTargetKiller(MoveToTarget npcMoveToTarget)
	{
		//killer is first character
		npcMoveToTarget.AddTarget(m_Characters[0]);
	}

	public void SetRandomTarget(MoveToTarget npcMoveToTarget)
	{
		npcMoveToTarget.AddTarget(m_Characters[Random.Range(0, m_Characters.Count)]);
	}
}
