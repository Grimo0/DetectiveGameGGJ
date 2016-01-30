﻿using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

    [SerializeField]
    NPCs npcs;
    [SerializeField]
    KillerBehavior killerBehaviour;
	[SerializeField]
	Level level;

    void Start()
    {
        npcs.Initialize();
        killerBehaviour.Initialize();
		npcs.GenerateNPCs(killerBehaviour.Missions);
		level.StartNPCBehaviours();
    }
}
