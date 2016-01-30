using UnityEngine;
using System.Collections.Generic;

public class KillerBehavior : MonoBehaviour {
	
	private Mission[] missions;
	public KillerUI killerUI;

	void Start () {
		Initialize();
	}

	public void Initialize() {
		GenerateMissions();
		killerUI.Initialize(missions);
	}

	private void GenerateMissions() {
		missions = new Mission[5];

		NPCs npcs = GetComponent<NPCs>();
		List<CharacterPart>[] parts = new List<CharacterPart>[4];
		parts[0] = new List<CharacterPart>(npcs.Hats);
		parts[1] = new List<CharacterPart>(npcs.Heads);
		parts[2] = new List<CharacterPart>(npcs.Bodies);
		parts[3] = new List<CharacterPart>(npcs.Pants);

		// MISSION 0
		missions[0] = new Mission();
		int iPart = Random.Range(0, 4);
		int iNumber = Random.Range(0, parts[iPart].Count);
		missions[0].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		// MISSION 1
		missions[1] = new Mission();
		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[1].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		// MISSION 2
		missions[2] = new Mission();
		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[2].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[2].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		// MISSION 3
		missions[3] = new Mission();
		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[3].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[3].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		// MISSION 4
		missions[4] = new Mission();
		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[4].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[4].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);

		while (parts[iPart].Count <= 0)
			iPart = Random.Range(0, 4);
		iNumber = Random.Range(0, parts[iPart].Count);
		missions[4].AddPart(parts[iPart][iNumber]);
		parts[iPart].RemoveAt(iNumber);
	}

	/**
	 * Return the mission index.
	 **/
	public int isATarget(NPC npc) {
		Appearance appearance = npc.GetComponent<Appearance>();
		int iP;
		for (int iM = 0; iM < missions.Length; iM++) {
			if (missions[iM].Finished) continue;
			for (iP = 0; iP < missions[iM].Parts.Count; iP++) {
				if (!appearance.HasPart(missions[iM].Parts[iP])) break;
			}
			if (iP < missions[iM].Parts.Count) continue;
			return iM;
		}
		return -1;
	}
}
