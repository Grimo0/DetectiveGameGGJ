using UnityEngine;
using System.Collections.Generic;

public class Mission {

	private List<CharacterPart> parts = new List<CharacterPart>();

	public void AddPart(CharacterPart part) {
		for (int i = 0; i < parts.Count; i++) {
			if (parts[0].category == part.category)
				return;
		}

		parts.Add(part);
	}

	public CharacterPart GetPart(int i) {
		return parts[i];
	}

	public bool Contain(CharacterPart rule) {
		return parts.Contains(rule);
	}
}
