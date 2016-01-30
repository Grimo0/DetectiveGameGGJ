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

	public void Initialize() {
		Mission[] missions = GetComponent<KillerBehavior>().missions;
	}
	
	void Update () {
	
	}
}
