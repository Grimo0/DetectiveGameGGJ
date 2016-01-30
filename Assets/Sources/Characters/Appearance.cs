using UnityEngine;
using System.Collections;

public class Appearance : MonoBehaviour {
	
	private CharacterPart hat;
	public SpriteRenderer hatRenderer;

	private CharacterPart head;
	public SpriteRenderer headRenderer;

	private CharacterPart body;
	public SpriteRenderer bodyRenderer;

	private CharacterPart pant;
	public SpriteRenderer pantRenderer;


	// Use this for initialization
	void Start() {
		
	}

	public void Initialize(CharacterPart hat, CharacterPart head, CharacterPart body, CharacterPart pant) {
		this.hat = hat;
		this.hatRenderer.sprite = hat.sprite;

		this.head = head;
		this.headRenderer.sprite = head.sprite;

		this.body = body;
		this.bodyRenderer.sprite = body.sprite;

		this.pant = pant;
		this.pantRenderer.sprite = pant.sprite;
	}
	
	// Update is called once per frame
	void Update() {
	
	}
}
