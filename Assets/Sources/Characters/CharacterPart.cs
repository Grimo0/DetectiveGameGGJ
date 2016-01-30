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

	public override bool Equals(object obj)
	{
		if (obj == null)
			return false;
		if (ReferenceEquals(this, obj))
			return true;
		if (obj.GetType() != typeof(CharacterPart))
			return false;
		CharacterPart other = (CharacterPart)obj;
		return _category == other._category && _name == other._name && category == other.category && name == other.name;
	}
	

	public override int GetHashCode()
	{
		unchecked {
			return _category.GetHashCode() ^ (_name != null ? _name.GetHashCode() : 0) ^ category.GetHashCode() ^ (name != null ? name.GetHashCode() : 0);
		}
	}
	
}

