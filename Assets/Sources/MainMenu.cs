using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void NewGame() {
		SceneManager.LoadScene("Scenes/Game");
	}

	public void Options() {
		transform.FindChild("MainMenu").gameObject.SetActive(false);
		transform.FindChild("OptionsMenu").gameObject.SetActive(true);
		transform.FindChild("Credits").gameObject.SetActive(false);
	}

	public void Credits() {
		transform.FindChild("MainMenu").gameObject.SetActive(false);
		transform.FindChild("OptionsMenu").gameObject.SetActive(false);
		transform.FindChild("Credits").gameObject.SetActive(true);
	}

	public void Exit() {
		Application.Quit();
	}

	public void Back() {
		transform.FindChild("MainMenu").gameObject.SetActive(true);
		transform.FindChild("OptionsMenu").gameObject.SetActive(false);
		transform.FindChild("Credits").gameObject.SetActive(false);
	}
}
