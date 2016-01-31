using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void NewGame() {
		transform.FindChild("MainMenu").gameObject.SetActive(false);
		transform.FindChild("HowToMenu").gameObject.SetActive(true);
		transform.FindChild("Credits").gameObject.SetActive(false);
	}

	public void Credits() {
		transform.FindChild("MainMenu").gameObject.SetActive(false);
		transform.FindChild("HowToMenu").gameObject.SetActive(false);
		transform.FindChild("Credits").gameObject.SetActive(true);
	}

	public void Exit() {
		Application.Quit();
	}

	public void Back() {
		transform.FindChild("MainMenu").gameObject.SetActive(true);
		transform.FindChild("HowToMenu").gameObject.SetActive(false);
		transform.FindChild("Credits").gameObject.SetActive(false);
	}
}
