using UnityEngine;
using System.Collections;

public class NPCs : MonoBehaviour {
	
	public GameObject prefabNPC, prefabKiller;

	public Level level;
	public KillerBehavior killerBehavior;

    public Transform charactersContainer;

    public int nbrOfCharacters;

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

	public void GenerateNPCs(Mission[] missions) {
		Appearance npcAppearance;
		CharacterPart[] parts;
		for (int i = 0; i < nbrOfCharacters; i++)
		{
			if (i == 0)
				npcAppearance = Instantiate(prefabKiller).GetComponent<Appearance>();
			else
				npcAppearance = Instantiate(prefabNPC).GetComponent<Appearance>();

			npcAppearance.transform.parent = charactersContainer;

			npcAppearance.transform.position = new Vector3(Random.Range(-25f, 25f), 1f, Random.Range(-25f, 25f));
			parts = new CharacterPart[4];
			parts[0] = _hats[Random.Range(0, _hats.Length)];
			parts[1] = _heads[Random.Range(0, _heads.Length)];
			parts[2] = _bodies[Random.Range(0, _bodies.Length)];
			parts[3] = _pants[Random.Range(0, _pants.Length)];
			npcAppearance.Initialize(parts);

			if (i >= 1 && i <= missions.Length) {
				for (int iP = 0; iP < missions[i - 1].Parts.Count; iP++) {
					npcAppearance.SetPart(missions[i - 1].Parts[iP]);
				}
			}

			level.AddCharacter(npcAppearance.transform);

			if(i > 0)
			{
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
			}
		}
	}
}
