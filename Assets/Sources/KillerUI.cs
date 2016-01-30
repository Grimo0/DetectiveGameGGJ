using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public SpriteRenderer[] mission0;
	public SpriteRenderer[] mission1;
	public SpriteRenderer[] mission2;
	public SpriteRenderer[] mission3;
	public SpriteRenderer[] mission4;


	void Start () {
	}

	public void Initialize(Mission[] missions) {
		mission0[0].sprite = missions[0].GetPart(0).sprite;

		mission1[0].sprite = missions[1].GetPart(0).sprite;

		mission2[0].sprite = missions[2].GetPart(0).sprite;
		mission2[1].sprite = missions[2].GetPart(1).sprite;

		mission3[0].sprite = missions[3].GetPart(0).sprite;
		mission3[1].sprite = missions[3].GetPart(1).sprite;

		mission4[0].sprite = missions[4].GetPart(0).sprite;
		mission4[1].sprite = missions[4].GetPart(1).sprite;
		mission4[2].sprite = missions[4].GetPart(2).sprite;
	}
	
	void Update () {
	
	}
}
