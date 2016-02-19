using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public SpriteRenderer[] missionRenderers = new SpriteRenderer[4];
	public Animator[] circles = new Animator[5];
	public Animator[] candles = new Animator[5];
	public SpriteRenderer nextText;
	public Timer timer;
	public int time;

	public AudioClip normalMusic;
	public AudioClip tenseMusic;
	public AudioClip bellClip;

	public AudioSource source;

	public FadeSound fadeSound;

	public Animator pentacle;

	private int ritualNumber;

	private float modelTimer = -1f;
	private float modelFinalAlpha;
	private float timerText = -1f;
	private float nextTextFinalAlpha;


	public void Initialize() {
		for (int i = 0; i < missionRenderers.Length; i++)
			missionRenderers[i].sprite = null;
	}

	public void SetMission(int ritualNumber, Mission mission)
    {
		this.ritualNumber = ritualNumber;
		modelTimer = 1f;
		modelFinalAlpha = 1f;
		if (ritualNumber != 0) {
			timerText = .5f;
			nextTextFinalAlpha = 0f;
		}

		timer.SetTime(time);
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
		if (modelTimer >= 0f) {
			modelTimer -= Time.deltaTime;
			Color c = missionRenderers[0].color;
			c.a = Mathf.Lerp(modelFinalAlpha, 1f - modelFinalAlpha, modelTimer);
			if (modelTimer < 0f) {
				c.a = modelFinalAlpha;
				modelTimer = -1f;
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
		modelTimer = 1f;
		modelFinalAlpha = 0f;
		circles[ritualNumber].SetTrigger("EndMissionTrigger");
		Invoke("LightCandle", .5f);

		//do it only once between 3rd and 4th skill
		if (ritualNumber == 2) {
			fadeSound.PlayFade(normalMusic, tenseMusic);
		}
	}

	private void LightCandle()
    {
		candles[ritualNumber].SetTrigger("EndMissionTrigger");
		timerText = 1f;
		nextTextFinalAlpha = 1f;

		source.PlayOneShot(bellClip);
	}

	private void StartTimer() {
		timer.StartTimer();
	}

	public void DoPentacleAnim()
    {
        pentacle.SetTrigger("DoAnim");
    }
}
