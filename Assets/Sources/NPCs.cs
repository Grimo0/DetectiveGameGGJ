using UnityEngine;
using System.Collections;

public class NPCs : MonoBehaviour {
	
	public GameObject prefabNPC;
	private CharacterPart[] _hats;
	private CharacterPart[] _heads; 
	private CharacterPart[] _bodies;
	private CharacterPart[] _pants;


	public CharacterPart[] Hats {
		get { return this._hats; }
	}

	public CharacterPart[] Heads {
		get { return this._heads; }
	}

	public CharacterPart[] Bodies {
		get { return this._bodies; }
	}

	public CharacterPart[] Pants {
		get { return this._pants; }
	}

	void Start() {
		Sprite[] hatSprites = Resources.LoadAll<Sprite>("Sprites/characters/hats");
		_hats = new CharacterPart[hatSprites.Length];
		for (int i = 0; i < hatSprites.Length; i++) {
			_hats[i] = new CharacterPart(hatSprites[i], CharacterPart.Category.HAT, "");
		}

		Sprite[] headSprites = Resources.LoadAll<Sprite>("Sprites/characters/head");
		_heads = new CharacterPart[headSprites.Length];
		for (int i = 0; i < headSprites.Length; i++) {
			_heads[i] = new CharacterPart(headSprites[i], CharacterPart.Category.HEAD, "");
		}

		Sprite[] bodySprites = Resources.LoadAll<Sprite>("Sprites/characters/body");
		_bodies = new CharacterPart[bodySprites.Length];
		for (int i = 0; i < bodySprites.Length; i++) {
			_bodies[i] = new CharacterPart(bodySprites[i], CharacterPart.Category.BODY, "");
		}

		Sprite[] pantSprites = Resources.LoadAll<Sprite>("Sprites/characters/pants");
		_pants = new CharacterPart[pantSprites.Length];
		for (int i = 0; i < pantSprites.Length; i++) {
			_pants[i] = new CharacterPart(pantSprites[i], CharacterPart.Category.PANT, "");
		}

		Appearance npcAppearance;
		for (int i = 0; i < 50; i++) {
			npcAppearance = GameObject.Instantiate(prefabNPC).GetComponent<Appearance>();
			npcAppearance.transform.position = new Vector3(Random.Range(-25f, 25f), 1f, Random.Range(-25f, 25f));
			npcAppearance.Initialize(
				_hats[Random.Range(0, _hats.Length - 1)],
				_heads[Random.Range(0, _heads.Length - 1)],
				_bodies[Random.Range(0, _bodies.Length - 1)],
				_pants[Random.Range(0, _pants.Length - 1)]);
		}
	}

	void Update() {
	
	}
}
