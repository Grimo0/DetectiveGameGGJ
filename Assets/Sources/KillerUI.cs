using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public SpriteRenderer[] missionRenderers = new SpriteRenderer[4];
	public Animator[] circles = new Animator[5];
	public Animator[] candles = new Animator[5];
	public SpriteRenderer nextText;
	public Timer timer;

	private int ritualNumber;

	public AudioClip normalMusic;
	public AudioClip tenseMusic;

	public FadeSound fadeSound;

	private float timerShow = -1f;
	private float modelFinalAlpha;
	private float timerText = -1f;
	private float nextTextFinalAlpha;

	public void SetMission(int ritualNumber, Mission mission) {
		this.ritualNumber = ritualNumber;
		timerShow = 1f;
		modelFinalAlpha = 1f;
		if (ritualNumber != 0) {
			timerText = .5f;
			nextTextFinalAlpha = 0f;
		}

		timer.SetTime(20 + 10 * (ritualNumber / 2));
		Invoke("StartTimer", .5f);

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
		if (timerShow >= 0f) {
			timerShow -= Time.deltaTime;
			Color c = missionRenderers[0].color;
			c.a = Mathf.Lerp(modelFinalAlpha, 1f - modelFinalAlpha, timerShow);
			if (timerShow < 0f) {
				c.a = modelFinalAlpha;
				timerShow = -1f;
			}
			for (int i = 0; i < missionRenderers.Length; i++) {
				missionRenderers[i].color = c;
			}
		}
		if (timerText >= 0f) {
			timerText -= Time.deltaTime;
			Color c = nextText.color;
			c.a = Mathf.Lerp(nextTextFinalAlpha, 1f - nextTextFinalAlpha, timerText);
			if (timerText < 0f) {
				c.a = nextTextFinalAlpha;
				timerText = -1f;
			}
			nextText.color = c;
		}
	}

	public void EndMission() {
		timer.StopTimer();
		timerShow = 1f;
		modelFinalAlpha = 0f;
		circles[ritualNumber].SetTrigger("EndMissionTrigger");
		Invoke("LightCandle", .5f);

		if (ritualNumber > 1) {
			fadeSound.PlayFade(normalMusic, tenseMusic);
		}
	}

	private void LightCandle() {
		candles[ritualNumber].SetTrigger("EndMissionTrigger");
		timerText = 1f;
		nextTextFinalAlpha = 1f;
	}

	private void StartTimer() {
		timer.StartTimer();
	}
}
