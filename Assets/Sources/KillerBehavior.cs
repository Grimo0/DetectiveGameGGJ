using UnityEngine;
using System.Collections;

public class KillerBehavior : MonoBehaviour {
	
	public Mission[] missions;

	void Start () {
		missions = new Mission[5];
		GenerateMissions();
	}

	private void GenerateMissions() {
		NPCs npcs = GetComponent<NPCs>();
		CharacterPart[][] parts = new CharacterPart[4][];
		parts[0] = npcs.Hats;
		parts[1] = npcs.Heads;
		parts[2] = npcs.Bodies;
		parts[3] = npcs.Pants;

		// 1 RULE RITUAL
		int iPart = Random.Range(0, 4);
		CharacterPart part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[0].AddPart(part);

		while (missions[0].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[1].AddPart(part);

		// 2 RULES RITUAL
		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[2].AddPart(part);

		while (missions[2].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[2].AddPart(part);

		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[3].AddPart(part);

		while (missions[3].Contain(part) || (missions[2].Contain(missions[3].GetPart(0)) && missions[2].Contain(part))) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[3].AddPart(part);

		// 3 RULES RITUAL
		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[4].AddPart(part);

		while (missions[4].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[4].AddPart(part);

		while (missions[4].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[4].AddPart(part);
	}
	
	void Update () {
	
	}
}
