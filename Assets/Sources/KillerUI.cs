using UnityEngine;
using System.Collections;

public class KillerUI : MonoBehaviour {

	public MissionUI[] missions = new MissionUI[5];

	public void Initialize(Mission[] missions) {
		this.missions[0].SetSprite(0, missions[0].Parts[0]);

		this.missions[1].SetSprite(0, missions[1].Parts[0]);

		this.missions[2].SetSprite(0, missions[2].Parts[0]);
		this.missions[2].SetSprite(1, missions[2].Parts[1]);

		this.missions[3].SetSprite(0, missions[3].Parts[0]);
		this.missions[3].SetSprite(1, missions[3].Parts[1]);

		this.missions[4].SetSprite(0, missions[4].Parts[0]);
		this.missions[4].SetSprite(1, missions[4].Parts[1]);
		this.missions[4].SetSprite(2, missions[4].Parts[2]);
	}
	
	public void EndMission(int iMission) {
		missions[iMission].fade();
	}

	private void SetSprite(SpriteRenderer renderer, CharacterPart part) {
		renderer.sprite = part.sprite;
		switch (part.category) {
		case (CharacterPart.Category.HAT):
			renderer.transform.localPosition = new Vector3(renderer.transform.localPosition.x, renderer.transform.localPosition.y - 42f / part.sprite.pixelsPerUnit, 0);
			break;

		case (CharacterPart.Category.HEAD):
			renderer.transform.localPosition = new Vector3(renderer.transform.localPosition.x, renderer.transform.localPosition.y - 34f / part.sprite.pixelsPerUnit, 0);
			break;

		case (CharacterPart.Category.BODY):
			renderer.transform.localPosition = new Vector3(renderer.transform.localPosition.x, renderer.transform.localPosition.y - 20f / part.sprite.pixelsPerUnit, 0);
			break;

		case (CharacterPart.Category.PANT):
			renderer.transform.localPosition = new Vector3(renderer.transform.localPosition.x, renderer.transform.localPosition.y - 7f / part.sprite.pixelsPerUnit, 0);
			break;
		}
	}
}
