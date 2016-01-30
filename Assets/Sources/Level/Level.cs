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

	public Transform GetRandomTarget()
	{
		//avoid picking killer
		return m_Characters[Random.Range(1, m_Characters.Count)];
	}

	public void StartNPCBehaviours()
	{
		//skip killer
		for (int i = 1; i < m_Characters.Count; i++)
		{
			NPC currentNPC = m_Characters[i].GetComponent<NPC>();
			currentNPC.StartBehaviour();
		}
	}
}
