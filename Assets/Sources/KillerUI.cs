using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public MissionUI[] missions = new MissionUI[5];


	void Start () {
	}

	public void Initialize(Mission[] missions) {
		this.missions[0].SetSprite(0, missions[0].Parts[0]);

		this.missions[1].SetSprite(0, missions[1].Parts[0]);

		this.missions[2].SetSprite(0, missions[2].Parts[0]);
		this.missions[2].SetSprite(1, missions[2].Parts[1]);

		this.missions[3].SetSprite(0, missions[3].Parts[0]);
		this.missions[3].SetSprite(1, missions[3].Parts[1]);

		this.missions[4].SetSprite(0, missions[4].Parts[0]);
		this.missions[4].SetSprite(1, missions[4].Parts[1]);
		this.missions[4].SetSprite(2, missions[4].Parts[2]);
	}
	
	public void EndMission(int iMission) {
		missions[iMission].fade();
	}

	void Update() {
		for (int i = 0; i < missions.Length; i++) {
			this.missions[i].Update();
		}
	}

}
