using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public SpriteRenderer[] missionRenderers = new SpriteRenderer[4];
	public Animator[] circles = new Animator[5];
	public Animator[] candles = new Animator[5];
	public SpriteRenderer nextText;

	public AudioClip normalMusic;
	public AudioClip tenseMusic;

	public FadeSound fadeSound;

	private float timerFade = -1f;
	private float timerShow = -1f;

	public void SetMission(Mission mission) {
		timerShow = 1f;
		for (int i = 0; i < missionRenderers.Length; i++) {
			if (i < mission.Parts.Count) {
				missionRenderers[i].sprite = mission.Parts[i].sprite;
				if (mission.Parts[i].category == CharacterPart.Category.HAT)
					missionRenderers[i].sortingOrder = 11;
				else
					missionRenderers[i].sortingOrder = 10;
			} else
				missionRenderers[i].sprite = null;
		}
	}

	void Update () {
		if (timerFade >= 0f) {
			timerFade -= Time.deltaTime;
			Color c = missionRenderers[0].color;
			c.a = Mathf.Lerp(0f, 1f, timerFade);
			if (timerFade < 0f) {
				c.a = 0f;
				timerFade = -1f;
			}
			missionRenderers[0].color = c;
			c.a = 1f - c.a;
			nextText.color = c;
		}
		if (timerShow >= 0f) {
			timerShow -= Time.deltaTime;
			Color c = missionRenderers[0].color;
			c.a = Mathf.Lerp(1f, 0f, timerShow);
			if (timerShow < 0f) {
				c.a = 1f;
				timerShow = -1f;
			}
			missionRenderers[0].color = c;
			c.a = 1f - c.a;
			nextText.color = c;
		}
	}

	public void EndMission(int ritualNumber) {
		timerFade = 1f;
		circles[ritualNumber].SetTrigger("EndMissionTrigger");
		candles[ritualNumber].SetTrigger("EndMissionTrigger");

		if (ritualNumber > 1)
		{
			fadeSound.PlayFade(normalMusic, tenseMusic);
		}
	}
}
