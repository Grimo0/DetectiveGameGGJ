using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ShootModeUI : MonoBehaviour {

    [SerializeField]
    Detective detective;
    [SerializeField]
	Sprite shootModeON;
	[SerializeField]
	Sprite shootModeOFF;

	[SerializeField]
	Image[] energyBars;

    bool shootMode = false;

    Image icon;

	float energyCounter;

    void Start()
    {
        icon = GetComponent<Image>();
    }

    void Update()
    {
        if (shootMode && (Input.GetButtonDown("Right_Click")))
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

	public void EnergyUsed()
	{
		energyBars[detective.energy].fillAmount = 0;
		StartCoroutine(UpdateEnergy(detective.energy, Time.time));
	}

	private IEnumerator UpdateEnergy(int energy, float energyCounter)
	{
		float speed = 1f / detective.energyDelay;
		while (Time.time - energyCounter < detective.energyDelay)
		{
			Image energyBar = energyBars[energy];
			energyBar.fillAmount = Mathf.Min(1, energyBar.fillAmount + Time.deltaTime * speed);

			yield return new WaitForEndOfFrame();
		}

		detective.energy++;
	}
}
