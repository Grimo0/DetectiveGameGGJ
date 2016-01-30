using UnityEngine;
using System.Collections;

public class Appearance : MonoBehaviour {
	
	private CharacterPart[] parts;
	public SpriteRenderer[] partsRenderer;


	public void Initialize(CharacterPart[] parts) {
		this.parts = parts;
		partsRenderer[0].sprite = parts[0].sprite;
		partsRenderer[1].sprite = parts[1].sprite;
		partsRenderer[2].sprite = parts[2].sprite;
		partsRenderer[3].sprite = parts[3].sprite;
	}

	public void SetPart(CharacterPart part) {
		for (int i = 0; i < parts.Length; i++) {
			if (part.category == parts[i].category) {
				parts[i] = part;
				partsRenderer[i].sprite = part.sprite;
				return;
			}
		}
	}

	public bool HasPart(CharacterPart part) {
		return part == parts[0] || part == parts[1] || part == parts[2] || part == parts[3];
	}
}
