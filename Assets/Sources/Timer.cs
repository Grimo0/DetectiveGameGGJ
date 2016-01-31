using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    TextMesh text;

	private int minutes = 2, seconds = 0;
    private string minutesStr, secondsStr;
	private float fadeTimer = -1f;

	public void SetTime(int sec) {
		minutes = sec / 60;
		seconds = sec - minutes * 60;
		text.color = Color.black;

		if (minutes == 0)
		{
			if (seconds == 20)
				text.color = Color.red;
			else if (seconds == 0)
				GetComponent<EndGame>().TimerFinished();
		}

		if (minutes == 0)
			minutesStr = "00";
		else
			minutesStr = minutes.ToString();

		if (seconds < 10)
			secondsStr = "0" + seconds;
		else
			secondsStr = seconds.ToString();
		
		text.text = minutesStr + "'" + secondsStr;
		fadeTimer = 1f;
		InvokeRepeating("Showing", 0f, .01f);
	}

	public void StartTimer()
	{
		CancelInvoke();
		Color c = text.color;
		c.a = 1f;
		text.color = c;
		fadeTimer = -1f;
		InvokeRepeating("RemoveOneSecond", 1f, 1f);
	}

	public bool IsStarted() {
		return IsInvoking();
	}

	public void StopTimer() {
		CancelInvoke();
		fadeTimer = .5f;
		InvokeRepeating("Fading", 0f, .01f);
	}

	private void Fading() {
		if (fadeTimer >= 0f) {
			fadeTimer -= Time.deltaTime;
			Color c = text.color;
			c.a = Mathf.Lerp(0f, 1f, fadeTimer);
			if (fadeTimer < 0f) {
				c.a = 0f;
				fadeTimer = -1f;
				CancelInvoke();
			}
			text.color = c;
		}
	}

	private void Showing() {
		if (fadeTimer >= 0f) {
			fadeTimer -= Time.deltaTime;
			Color c = text.color;
			c.a = Mathf.Lerp(1f, 0f, fadeTimer);
			if (fadeTimer < 0f) {
				c.a = 1f;
				fadeTimer = -1f;
				CancelInvoke();
			}
			text.color = c;
		}
	}

    private void RemoveOneSecond()
	{
        if (seconds == 0)
        {
            seconds = 59;
            minutes--;
        }
        else
			seconds--;
		
		if (minutes == 0)
		{
			if (seconds == 20)
				text.color = Color.red;
			else if (seconds == 0)
				GameObject.Find("GameManager").GetComponent<EndGame>().TimerFinished();
		}

        if (minutes == 0)
            minutesStr = "00";
        else
            minutesStr = minutes.ToString();

        if (seconds < 10)
            secondsStr = "0" + seconds;
        else
            secondsStr = seconds.ToString();

        text.text = minutesStr + "'" + secondsStr;
    }
}
