using UnityEngine;
using System.Collections;

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
		CharacterPart[][] parts = new CharacterPart[4][];
		parts[0] = npcs.Hats;
		parts[1] = npcs.Heads;
		parts[2] = npcs.Bodies;
		parts[3] = npcs.Pants;

		// 1 RULE RITUAL
		missions[0] = new Mission();
		int iPart = Random.Range(0, 4);
		CharacterPart part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[0].AddPart(part);

		missions[1] = new Mission();
		while (missions[0].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[1].AddPart(part);

		// 2 RULES RITUAL
		missions[2] = new Mission();
		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[2].AddPart(part);

		while (missions[2].Contain(part)) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[2].AddPart(part);

		missions[3] = new Mission();
		iPart = Random.Range(0, 4);
		part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		missions[3].AddPart(part);

		while (missions[3].Contain(part) || (missions[2].Contain(missions[3].GetPart(0)) && missions[2].Contain(part))) {
			iPart = Random.Range(0, 4);
			part = parts[iPart][Random.Range(0, parts[iPart].Length)];
		}
		missions[3].AddPart(part);

		// 3 RULES RITUAL
		missions[4] = new Mission();
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
