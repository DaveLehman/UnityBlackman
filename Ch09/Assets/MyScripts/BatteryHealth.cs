using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryHealth : MonoBehaviour {
    public float batteryFull = 70.0f;   // number of seconds left in battery
    float batteryRemaining;              // remaining battery life in seconds
    int percentRemaining;
    internal bool trackingBattery = true;               // timer started/not started
    public Text batteryText;
    public GameObject energyBar;                // energy bar sprite
    float baseScale;

	// Use this for initialization
	void Start () {
        print("battery script running");
        if (batteryText == null)
            print("Can't find text item");
        if (energyBar == null)
            print("Can't find energy bar item");
	    // find the HUD and set the starting batter values
        batteryRemaining = batteryFull;
        batteryText.color = Color.green;
        batteryText.text = percentRemaining.ToString() + "%";
        baseScale = energyBar.transform.localScale.y;
        //print("current text and color for found object is " + batteryText.text.ToString() + ", " + batteryText.color.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	    if (trackingBattery)
        {
            if (batteryRemaining > 0)
            {
                batteryRemaining -= Time.deltaTime; // second countdown
                percentRemaining = (int)((batteryRemaining / batteryFull) * 100);
                //print("Recalc percentRemaining at " + percentRemaining.ToString());
                UpdateBattery();
                if(percentRemaining <= 25)
                {
                    batteryText.color = Color.red;
                }
                else
                {
                    if(percentRemaining <= 50)
                    {
                        batteryText.color = Color.yellow;
                    }
                    else
                        batteryText.color = Color.green;
                }
                batteryText.text = percentRemaining.ToString() + "%";
            }
            else
            {
                GameOver();
                trackingBattery = false;
            }
        }
	}

    private void UpdateBattery()
    {
        // animate the battery's energy bar to match percent remaining
        Vector3 adjustedScale = energyBar.transform.localScale; // store the sprite's scale in a temp var
        adjustedScale.y = baseScale * (batteryRemaining / batteryFull); // calc the actual y scale
        energyBar.transform.localScale = adjustedScale;
        // if less than 50% and greater than 25%, adjust color - raise red to get yellow
        if (percentRemaining <= 50 && percentRemaining > 25)
        {
            float adj = (50 - percentRemaining) * .04f; // adjusted for curent percent
            energyBar.GetComponent<Image>().color = new Color(0f + adj, 1f, 0f);
        }
        // if less than or equal to 25%, adjust color drop grom green to get red
        if (percentRemaining <= 25)
        {
            float adj = (25 - percentRemaining) * .04f; // adjusted for curent percent
            energyBar.GetComponent<Image>().color = new Color(1f, 1f-adj, 0f);
        }
    }

    private void GameOver()
    {
        print("Game Over");
        // deactivate the potato gun
        GameObject.Find("Fire Point").SetActive(false);
        // disable navigation
        GameObject.Find("Gnomatic Garden Defender").GetComponent<CharacterMotor>().enabled = false;
        // disable turning
        GameObject.Find("Gnomatic Garden Defender").GetComponent<MouseLook>().enabled = false;
    }
}
