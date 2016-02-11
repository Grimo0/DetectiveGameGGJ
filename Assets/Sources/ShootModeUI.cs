using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class ShootModeUI : MonoBehaviour {

    [SerializeField]
	private Detective detective;
    [SerializeField]
	private Sprite shootModeON;
	[SerializeField]
	private Sprite shootModeOFF;

	[SerializeField]
	private Image[] energyBars;

	private bool shootMode = false;

	private Image icon;

	private float energyCounter;

	private List<int> energyBarIndices = new List<int>{0,1,2};

    void Start()
    {
        icon = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Right_Click"))
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
		int energyIndex = energyBarIndices[energyBarIndices.Count - 1];

		energyBars[energyIndex].fillAmount = 0;
		StartCoroutine(UpdateEnergy(energyIndex, Time.time));
	}

	private IEnumerator UpdateEnergy(int energy, float energyCounter)
	{
		energyBarIndices.Remove(energy);
	
		float speed = 1f / detective.energyDelay;
		while (Time.time - energyCounter < detective.energyDelay)
		{
			Image energyBar = energyBars[energy];
			energyBar.fillAmount = Mathf.Min(1, energyBar.fillAmount + Time.deltaTime * speed);

			yield return new WaitForEndOfFrame();
		}

		detective.energy++;
		energyBarIndices.Add(energy);
		energyBarIndices.Sort();
	}
}
