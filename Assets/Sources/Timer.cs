using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    TextMesh text;

    int minutes = 2, seconds = 0;
    string minutesStr, secondsStr;

	void Start ()
    {
        InvokeRepeating("RemoveOneSecond", 1f, 1f);
	}

    void RemoveOneSecond()
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
                GetComponent<EndGame>().TimerFinished();
        }

        if (minutes < 10)
            minutesStr = "0" + minutes;
        else
            minutesStr = minutes.ToString();

        if (seconds < 10)
            secondsStr = "0" + seconds;
        else
            secondsStr = seconds.ToString();

        text.text = minutesStr + ":" + secondsStr;
    }
}
