using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGame : MonoBehaviour {

    [SerializeField]
    GameObject endScreen;

    [SerializeField]
    Text infoText;

	[SerializeField]
	FadeSound fadeSound;

	[SerializeField]
	AudioClip cukooClip;
	[SerializeField]
	AudioClip killerClip;

	[SerializeField]
	AudioSource source;

    public void TimerFinished()
    {
        ShowEndGameScreen(false);
        infoText.text = "The killer ran out of time.\nThe detective wins the game.";
    }

    public void WrongKillerKilled()
    {
        ShowEndGameScreen(true);
        infoText.text = "The detective killed the wrong guy.\nThat one was not the killer.";
    }

    public void KillerWins()
    {
        ShowEndGameScreen(true);
        infoText.text = "The killer has finished his ritual.\nThe apocalypse has started.";
    }

    public void DetectiveWins()
    {
        ShowEndGameScreen(false);
        infoText.text = "The detective unmasked the killer.\nThe killer has lost the game.";
    }

	void ShowEndGameScreen(bool hasKillerWon)
    {
        Time.timeScale = 0f;
        endScreen.SetActive(true);

		fadeSound.Stop();

		AudioClip clip = hasKillerWon ? killerClip : cukooClip;
		source.PlayOneShot(clip);

		Cursor.SetCursor(null, Vector3.zero, CursorMode.Auto);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
