using UnityEngine;
using System.Collections.Generic;

public class Mission {

	private List<CharacterPart> parts = new List<CharacterPart>();


	public void AddPart(CharacterPart part) {
		Contain(part);

		parts.Add(part);
	}

	public CharacterPart GetPart(int i) {
		return parts[i];
	}

	public bool Contain(CharacterPart part) {
		return parts.Contains(part);
	}
}
