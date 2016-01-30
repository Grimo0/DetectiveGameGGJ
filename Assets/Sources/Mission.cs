using UnityEngine;
using System.Collections.Generic;

public class Mission {

	private bool _finished = false;
	private List<CharacterPart> _parts = new List<CharacterPart>();

	public bool Finished {
		get { return this._finished; }
		set { _finished = value; }
	}

	public List<CharacterPart> Parts {
		get { return this._parts; }
	}


	public bool AddPart(CharacterPart part) {
		if (HasCategory(part))
			return false;

		_parts.Add(part);
		return true;
	}

	public bool HasCategory(CharacterPart part) {
		for (int i = 0; i < _parts.Count; i++) {
			if (part.category == _parts[i].category) return true;
		}
		return false;
	}
}
