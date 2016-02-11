using UnityEngine;
using System.Collections.Generic;

public class KillerBehavior : MonoBehaviour {
	
	private Mission currentMission;
	private int ritualNumber;
	public KillerUI killerUI;

	public Mission CurrentMission {
		get { return this.currentMission; }
	}

	public int RitualNumber {
		get { return this.ritualNumber; }
	}


	public void Initialize() {
		ritualNumber = 0;
		killerUI.Initialize();
	}

	public void NewMission() {
		if (CheckWin())
			return;
		
		currentMission = new Mission();
		List<Appearance> npcs = GameObject.Find("GameManager").GetComponent<NPCs>().Npcs;
		Appearance target = npcs[Random.Range(0, npcs.Count)];
		int partsNumber = ritualNumber;
		if (ritualNumber == 0)
			partsNumber = 4;
		for (int i = 0; i < partsNumber; i++) {
			while (!currentMission.AddPart(target.Parts[Random.Range(0, target.Parts.Length)]));
		}
		killerUI.SetMission(ritualNumber, currentMission);
	}


	public bool IsTarget(NPC npc) {
		Appearance appearance = npc.GetComponent<Appearance>();
		if (currentMission.Finished) 
			return false;
		for (int iP = 0; iP < currentMission.Parts.Count; iP++) {
			if (!appearance.HasPart(currentMission.Parts[iP])) 
				return false;
		}
		return true;
	}

	public bool Kill(NPC npc) {
		if (IsTarget(npc)) {
			killerUI.EndMission();
			currentMission.Finished = true;
			ritualNumber++;
			Invoke("NewMission", 3f);
			return true;
		}
		return false;
	}

    bool CheckWin()
    {
		if (ritualNumber < 5)
			return false;
        GetComponent<EndGame>().KillerWins();
		return true;
    }
}
