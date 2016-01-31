using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HowToScreen : MonoBehaviour {

	private bool killerPressed = false;
	private bool detectivePressed = false;
	
	void Update () {
		if (Input.GetButtonDown("Controller_Action") || Input.GetKeyDown(KeyCode.Space))
			killerPressed = true;
		if (Input.GetButtonDown("Left_Click"))
			detectivePressed = true;
		if (killerPressed && detectivePressed)
			SceneManager.LoadScene("Scenes/Game");
	}
}
