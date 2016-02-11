using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Path
{
	public string Name;

	public Transform[] Waypoints;
}

[System.Serializable]
public class Solo
{
	public string Name;

	public Transform Waypoint;
}

public class Level : MonoBehaviour 
{
	[SerializeField]
	private List<Path> m_Paths;

	[SerializeField]
	private List<Solo> m_Solos;

	private List<Transform> m_Characters = new List<Transform>();


	public void AddCharacter(Transform character)
	{
		Path path = m_Paths[Random.Range(0, m_Paths.Count)];
		character.position = path.Waypoints[Random.Range(0, path.Waypoints.Length)].position;
		m_Characters.Add(character);
	}
		
	public void SetRandomPath(MoveToWaypoints npcMoveToWaypoints)
	{		
		Path path = m_Paths[Random.Range(0, m_Paths.Count)];
		npcMoveToWaypoints.AddWaypoints(path.Waypoints);
	}

	public Transform GetRandomTarget()
	{
		return m_Characters[Random.Range(0, m_Characters.Count)];
	}

	public Transform GetRandomSolo()
	{
		return m_Solos[Random.Range(0, m_Solos.Count)].Waypoint;
	}

	public void StartNPCBehaviours()
	{
		for (int i = 1; i < m_Characters.Count; i++)
		{
			NPC currentNPC = m_Characters[i].GetComponent<NPC>();
			currentNPC.StartBehaviour();
		}
	}
}
