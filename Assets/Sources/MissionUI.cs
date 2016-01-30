using UnityEngine;
using System.Collections;

[System.Serializable]
public class MissionUI {

	public SpriteRenderer[] mission;
    public SpriteRenderer DONE;

	private float time = -1f;

	public void SetSprite(int iPart, CharacterPart part) {
		mission[iPart].sprite = part.sprite;
	}
	
	void Update () {
		if (time > 0) {
			time -= Time.deltaTime;
			Color c = mission[0].material.color;
			c.a = Mathf.Lerp(0f, 1f, time);
			if (time < 0)
				c.a = 0;
		}
	}

	public void fade() {
		time = 1f;
        DONE.enabled = true;
	}
}
