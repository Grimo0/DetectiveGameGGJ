using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {
	[SerializeField]
	private GameObject mainMenu;
	[SerializeField]
	private GameObject howToMenu;
	[SerializeField]
	private GameObject credits;


	public void NewGame() {
		mainMenu.gameObject.SetActive(false);
		howToMenu.gameObject.SetActive(true);
		credits.gameObject.SetActive(false);
	}

	public void Credits() {
		mainMenu.gameObject.SetActive(false);
		howToMenu.gameObject.SetActive(false);
		credits.gameObject.SetActive(true);
	}

	public void Exit() {
		Application.Quit();
	}

	public void Back() {
		mainMenu.gameObject.SetActive(true);
		howToMenu.gameObject.SetActive(false);
		credits.gameObject.SetActive(false);
	}

	public void Update() {
		if (Input.GetButtonDown("Cancel")) {
			Back();
		}
	}
}
