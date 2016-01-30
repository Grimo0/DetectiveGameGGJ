using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMouseOver : MonoBehaviour {

    SpriteRenderer spriteRenderer;
    Sprite selectedSprite;

    private bool isSelected;
    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            if(value && !isSelected)
                isSelected = spriteRenderer.enabled = true;
            else if(!value && isSelected)
                isSelected = spriteRenderer.enabled = false;
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        selectedSprite = Resources.Load<Sprite>("Sprites/characters/selected");

        spriteRenderer.sprite = selectedSprite;
    }
}
