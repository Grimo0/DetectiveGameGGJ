using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterPart {

	public enum Category {HAT, HEAD, BODY, PANT};

	private Sprite _sprite;
	private Category _category;
	private string _name;


	public CharacterPart(Sprite sprite, Category category, string name) {
		this._sprite = sprite;
		this.category = category;
		this.name = name;
	}

	public Sprite sprite { get{ return _sprite;} }
	public Category category { get{ return _category;} set{ _category = value;} }
	public string name { get{ return _name;} set{ _name = value;} }
}

