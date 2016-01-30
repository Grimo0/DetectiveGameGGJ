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
		SetSprite(mission0[0], missions[0].GetPart(0));

		SetSprite(mission1[0], missions[1].GetPart(0));

		SetSprite(mission2[0], missions[2].GetPart(0));
		SetSprite(mission2[1], missions[2].GetPart(1));

		SetSprite(mission3[0], missions[3].GetPart(0));
		SetSprite(mission3[1], missions[3].GetPart(1));

		SetSprite(mission4[0], missions[4].GetPart(0));
		SetSprite(mission4[1], missions[4].GetPart(1));
		SetSprite(mission4[2], missions[4].GetPart(2));
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
	
	void Update () {
	
	}
}
