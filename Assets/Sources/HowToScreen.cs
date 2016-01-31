using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class HowToScreen : MonoBehaviour {

	private bool killerPressed = false;
	private bool detectivePressed = false;
	public Text pressENTER;
	public Text pressA;
	
	void Update () {
		if (Input.GetButtonDown("Controller_Action") || Input.GetKeyDown(KeyCode.Space)) {
			pressA.text = "READY!";
			killerPressed = true;
		}
		if (Input.GetButtonDown("Left_Click")) {
			pressENTER.text = "READY!";
			detectivePressed = true;
		}
		if (killerPressed && detectivePressed)
			SceneManager.LoadScene("Scenes/Game");
	}
}
