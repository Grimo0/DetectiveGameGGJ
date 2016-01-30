using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HowToScreen : MonoBehaviour {

	private bool killerPressed = false;
	private bool detectivePressed = false;

	void Start () {
		
	}
	
	void Update () {
		if ((Input.GetButton("Controller_Action") || Input.GetKey(KeyCode.Space)) && Input.GetButton("Left_Click"))
			SceneManager.LoadScene("Scenes/Game");
	}
}
