using UnityEngine;
using System.Collections;

public class Appearance : MonoBehaviour {
	
	private CharacterPart _hat;
	public SpriteRenderer hatRenderer;

	private CharacterPart _head;
	public SpriteRenderer headRenderer;

	private CharacterPart _body;
	public SpriteRenderer bodyRenderer;

	private CharacterPart _pant;
	public SpriteRenderer pantRenderer;


	// Use this for initialization
	void Start() {
		
	}

	public void Initialize(CharacterPart hat, CharacterPart head, CharacterPart body, CharacterPart pant) {
		this._hat = hat;
		this.hatRenderer.sprite = hat.sprite;

		this._head = head;
		this.headRenderer.sprite = head.sprite;

		this._body = body;
		this.bodyRenderer.sprite = body.sprite;

		this._pant = pant;
		this.pantRenderer.sprite = pant.sprite;
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	public bool HasPart(CharacterPart part) {
		return part == _hat || part == _head || part == _body || part == _pant;
	}
}
