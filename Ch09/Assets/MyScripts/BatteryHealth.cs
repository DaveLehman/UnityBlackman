using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryHealth : MonoBehaviour {
    public float batteryFull = 70.0f;   // number of seconds left in battery
    float batteryRemaining;              // remaining battery life in seconds
    int percentRemaining;
    bool trackingBattery = true;               // timer started/not started
    public Text guiText;

	// Use this for initialization
	void Start () {
	    // find the HUD and set the starting batter values
        batteryRemaining = batteryFull;
        guiText.color = Color.green;
        guiText.text = "Battery: " + percentRemaining.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	    if (trackingBattery)
        {
            if (batteryRemaining > 0)
            {
                batteryRemaining -= Time.deltaTime; // second countdown
                percentRemaining = (int)((batteryRemaining / batteryFull) * 100);
                if(percentRemaining <= 10)
                {
                    guiText.color = Color.red;
                }
                else
                {
                    guiText.color = Color.green;
                }
                guiText.text = "Battery: " + percentRemaining.ToString();
            }
            else
            {
                GameOver();
                trackingBattery = false;
            }
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
