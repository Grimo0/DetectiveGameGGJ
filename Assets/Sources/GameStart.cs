using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour {

    [SerializeField]
    private NPCs npcs;
    [SerializeField]
    private KillerBehavior killerBehaviour;
	[SerializeField]
	private Level level;

	[SerializeField]
	private AudioClip killerClip;

	[SerializeField]
	private AudioSource clip;

	[SerializeField]
	private AudioSource background;

	private bool killerStart;


    public void StartGame()
    {
		killerStart = false;
        npcs.Initialize();
		npcs.GenerateKiller();
		killerBehaviour.Initialize();

		//play background music
		background.Play();
    }

	public void Update() {
		if(!killerStart && Input.GetButtonDown("Controller_Action"))
		{
			killerStart = true;
			clip.PlayOneShot(killerClip);
			npcs.GenerateNPCs();
			level.StartNPCBehaviours();
			killerBehaviour.NewMission();
		}
	}
}
