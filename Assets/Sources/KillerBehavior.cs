﻿using UnityEngine;
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
		NewMission();
		killerUI.SetMission(currentMission);
	}

	public void NewMission() {
		currentMission = new Mission();
		List<Appearance> npcs = GameObject.Find("GameManager").GetComponent<NPCs>().npcs;
		Appearance target = npcs[Random.Range(0, npcs.Count)];
		for (int i = 0; i < ritualNumber / 2 + 1; i++) {
			while (!currentMission.AddPart(target.Parts[Random.Range(0, target.Parts.Length)]));
		}
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
			killerUI.EndMission(ritualNumber);
			currentMission.Finished = true;
			ritualNumber++;
			NewMission();
			killerUI.SetMission(currentMission);
            CheckWin();
			return true;
		}
		return false;
	}

    void CheckWin()
    {
		if (ritualNumber < 5)
			return;
        GetComponent<EndGame>().KillerWins();
    }
}
