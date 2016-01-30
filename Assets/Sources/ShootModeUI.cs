using UnityEngine;
using UnityEngine.UI;

public class ShootModeUI : MonoBehaviour {

    [SerializeField]
    Detective detective;
    [SerializeField]
    Sprite shootModeON, shootModeOFF;

    bool shootMode = false;

    Image icon;

    void Start()
    {
        icon = GetComponent<Image>();
    }

    void Update()
    {
        if (shootMode && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
            ToggleShootMode();
    }

	public void ToggleShootMode()
    {
        shootMode = !shootMode;
        detective.ShootMode = shootMode;

        if (shootMode)
            icon.sprite = shootModeOFF;
        else
            icon.sprite = shootModeON;
    }
}
