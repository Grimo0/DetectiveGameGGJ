using UnityEngine;
using System.Collections.Generic;

public class NPCs : MonoBehaviour {

	public GameObject prefabNPC, prefabKiller;

	public Level level;
	public KillerBehavior killerBehavior;

    public Transform charactersContainer;

	[SerializeField]
    private int nbrOfCharacters;

	private List<Appearance> npcs;
    private CharacterPart[] _hats;
	private CharacterPart[] _heads; 
	private CharacterPart[] _bodies;
	private CharacterPart[] _pants;

	public List<Appearance> Npcs {
		get { return this.npcs; }
	}

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


	public void Initialize()
    {
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
	}

	public void GenerateKiller() {
		Appearance appearance;
		CharacterPart[] parts;

		appearance = Instantiate(prefabKiller).GetComponent<Appearance>();

		appearance.transform.parent = charactersContainer;

		parts = new CharacterPart[4];
		parts[0] = _hats[Random.Range(0, _hats.Length)];
		parts[1] = _heads[Random.Range(0, _heads.Length)];
		parts[2] = _bodies[Random.Range(0, _bodies.Length)];
		parts[3] = _pants[Random.Range(0, _pants.Length)];
		appearance.Initialize(parts);

		level.AddCharacter(appearance.transform);
	}

	public void GenerateNPCs() {
		npcs = new List<Appearance>();
		Appearance npcAppearance;
		CharacterPart[] parts;
		for (int i = 0; i < nbrOfCharacters; i++)
		{
			npcAppearance = Instantiate(prefabNPC).GetComponent<Appearance>();

			npcAppearance.transform.parent = charactersContainer;

			parts = new CharacterPart[4];
			parts[0] = _hats[Random.Range(0, _hats.Length)];
			parts[1] = _heads[Random.Range(0, _heads.Length)];
			parts[2] = _bodies[Random.Range(0, _bodies.Length)];
			parts[3] = _pants[Random.Range(0, _pants.Length)];
			npcAppearance.Initialize(parts);

			level.AddCharacter(npcAppearance.transform);
			npcs.Add(npcAppearance);

			NPC npc = npcAppearance.GetComponent<NPC>();
			MoveToTarget npcMoveToTarget = npc.GetMoveToTarget();
			if (npcMoveToTarget != null)
			{
				npcMoveToTarget.Init(killerBehavior, level);
			}

			MoveToWaypoints npcMoveToWaypoints = npc.FindBehaviour<MoveToWaypoints>();
			if (npcMoveToWaypoints != null)
			{
				level.SetRandomPath(npcMoveToWaypoints);
			}

			MoveToNewWaypoints npcMoveToNewWaypoints = npc.FindBehaviour<MoveToNewWaypoints>();
			if (npcMoveToNewWaypoints != null)
			{
				npcMoveToNewWaypoints.Init(level);
			}

			MoveToSolo npcMoveToSolo = npc.FindBehaviour<MoveToSolo>();
			if (npcMoveToSolo != null)
			{
				npcMoveToSolo.Init(level);
			}
		}
	}

	public void RemoveNPC(Appearance npc) {
		npcs.Remove(npc);
	}
}
