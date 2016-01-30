using UnityEngine;
using System.Collections.Generic;

public class Mission {

	private List<CharacterPart> rules = new List<CharacterPart>();

	public void AddRule(CharacterPart part) {
		for (int i = 0; i < rules.Count; i++) {
			if (rules[0].category == part.category)
				return;
		}

		rules.Add(part);
	}

	public CharacterPart GetRule(int i) {
		return rules[i];
	}

	public bool Contain(CharacterPart rule) {
		return rules.Contains(rule);
	}
}
