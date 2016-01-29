using UnityEngine;
using System.Collections;

public class Appearance : MonoBehaviour {
	public SpriteRenderer hat;
	public SpriteRenderer head;
	public SpriteRenderer torso;
	public SpriteRenderer pant;

	// Use this for initialization
	void Start () {
		
	}

	public void Initialize(Sprite hat, Sprite head, Sprite torso, Sprite pant) {
		this.hat.sprite = hat;
		this.head.sprite = head;
		this.torso.sprite = torso;
		this.pant.sprite = pant;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
