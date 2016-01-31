using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

    [SerializeField]
    NPCs npcs;
    [SerializeField]
    KillerBehavior killerBehaviour;
	[SerializeField]
	Level level;

	[SerializeField]
	AudioSource source;

    public void StartGame()
    {
        npcs.Initialize();
        killerBehaviour.Initialize();
		level.StartNPCBehaviours();

		//play background music
		source.Play();
    }
}
