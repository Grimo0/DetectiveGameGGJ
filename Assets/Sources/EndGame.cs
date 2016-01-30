using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGame : MonoBehaviour {

    [SerializeField]
    GameObject endScreen;

    [SerializeField]
    Text infoText;

    public void TimerFinished()
    {
        ShowEndGameScreen();
        infoText.text = "The killer ran out of time.\nThe detective wins the game.";
    }

    public void WrongKillerKilled()
    {
        ShowEndGameScreen();
        infoText.text = "The detective killed the wrong guy.\nThat one was not the killer.";
    }

    public void KillerWins()
    {
        ShowEndGameScreen();
        infoText.text = "The killer has finished his ritual.\nThe apocalypse has started.";
    }

    public void DetectiveWins()
    {
        ShowEndGameScreen();
        infoText.text = "The detective unmasked the killer.\nThe killer has lost the game.";
    }

    void ShowEndGameScreen()
    {
        Time.timeScale = 0f;
        endScreen.SetActive(true);
    }
}
