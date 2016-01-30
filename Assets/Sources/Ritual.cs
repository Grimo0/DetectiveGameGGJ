using UnityEngine;
using System.Collections;

public class Ritual : MonoBehaviour {
	
	public Mission[] missions;

	void Start () {
	}

	private void GenerateMissions() {
		NPCs npcs = GetComponent<NPCs>();
		CharacterPart[][] parts = new CharacterPart[4][];
		parts[0] = npcs.Hats;
		parts[1] = npcs.Heads;
		parts[2] = npcs.Bodies;
		parts[3] = npcs.Pants;

		missions = new Mission[5];

		// 1 RULE RITUAL
		int iPart = Random.Range(0, 4);
		CharacterPart part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[0].AddRule(part);

		while (missions[0].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[1].AddRule(part);

		// 2 RULES RITUAL
		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[2].AddRule(part);

		while (missions[2].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[2].AddRule(part);

		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[3].AddRule(part);

		while (missions[3].Contain(part) || (missions[2].Contain(missions[3].GetRule(0)) && missions[2].Contain(part))) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[3].AddRule(part);

		// 3 RULES RITUAL
		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[4].AddRule(part);

		while (missions[4].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[4].AddRule(part);

		while (missions[4].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[4].AddRule(part);
	}
	
	void Update () {
	
	}
}
