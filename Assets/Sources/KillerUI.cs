using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public SpriteRenderer[] missionRenderers = new SpriteRenderer[3];
	public Animator[] circles = new Animator[5];
	public Animator[] candles = new Animator[5];

	public AudioClip normalMusic;
	public AudioClip tenseMusic;

	public FadeSound fadeSound;

	private float time = -1f;

	public void SetMission(Mission mission) {
		for (int i = 0; i < missionRenderers.Length; i++) {
			if (i < mission.Parts.Count)
				missionRenderers[i].sprite = mission.Parts[i].sprite;
			else
				missionRenderers[i].sprite = null;
		}
	}

	void Update () {
		if (time >= 0f) {
			time -= Time.deltaTime;
			Color c = missionRenderers[0].material.color;
			c.a = Mathf.Lerp(0f, 1f, time);
			if (time < 0f) {
				c.a = 0f;
				time = -1f;
			}
		}
	}

	public void EndMission(int ritualNumber) {
		time = 1f;
		circles[ritualNumber].SetTrigger("EndMissionTrigger");
		candles[ritualNumber].SetTrigger("EndMissionTrigger");

		if (ritualNumber > 1)
		{
			fadeSound.PlayFade(normalMusic, tenseMusic);
		}
	}
}
