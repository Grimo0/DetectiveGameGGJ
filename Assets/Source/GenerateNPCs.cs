using UnityEngine;
using System.Collections;

public class GenerateNPCs : MonoBehaviour {
	public GameObject prefabNPC;
	private Sprite[] hats;
	private Sprite[] heads; 
	private Sprite[] torsos;
	private Sprite[] pants;

	// Use this for initialization
	void Start () {
		hats = Resources.LoadAll<Sprite>("Sprites/characters/hats");
		heads = Resources.LoadAll<Sprite>("Sprites/characters/head");
		torsos = Resources.LoadAll<Sprite>("Sprites/characters/body");
		pants = Resources.LoadAll<Sprite>("Sprites/characters/pants");

		Appearance npcAppearance;
		for (int i = 0; i < 50; i++) {
			npcAppearance = GameObject.Instantiate(prefabNPC).GetComponent<Appearance>();
			//npcAppearance.transform.localScale = new Vector3(10f, 1f, 10f);
			npcAppearance.transform.Rotate(new Vector3(90f, 0f, 0f));
			npcAppearance.transform.position = new Vector3(Random.Range(-25f, 25f), 1f, Random.Range(-25f, 25f));
			npcAppearance.Initialize(
				hats[Random.Range(0, hats.Length - 1)],
				heads[Random.Range(0, heads.Length - 1)],
				torsos[Random.Range(0, torsos.Length - 1)],
				pants[Random.Range(0, pants.Length - 1)]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
