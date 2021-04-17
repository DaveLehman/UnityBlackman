using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BatteryHealth : MonoBehaviour {
    public float batteryFull = 70f;      // battery life in seconds
    float batteryRemaining;              // battery life remaining in seconds
    int percentRemaining;
    bool trackingBattery = true;         // controls timer
    public Text guiText;                   // the GUI Text component
    public GameObject energyBar;
    float baseScale;
                   
	// Use this for initialization
	void Start () {
        batteryRemaining = batteryFull;
        guiText = GetComponent<Text>();
        guiText.text = "100%";
        baseScale = energyBar.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
	    if (trackingBattery)
        {
            if (batteryRemaining > 0)
            {
                batteryRemaining -= Time.deltaTime;

                percentRemaining = (int)((batteryRemaining / batteryFull) * 100);
                guiText.text = percentRemaining.ToString() + "%";
                UpdateBattery();
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
        //adjust batter's energy bar sprite
        Vector3 adjustedScale = energyBar.transform.localScale;
        adjustedScale.y = baseScale * (batteryRemaining / batteryFull);
        energyBar.transform.localScale = adjustedScale;
        // set the colors
        // if less than 50% and greater than 25% raise red to get yellow
        if(percentRemaining <= 50 && percentRemaining > 25)
        {
            float adj = (50 - percentRemaining) * 0.04f;
            Color current = new Color(0f + adj, 1f, 0f);
            energyBar.GetComponent<SpriteRenderer>().color = current;
            guiText.color = current;
        }
        // if less than or equal to 25% drop green to get red
        if (percentRemaining <= 25)
        {
            float adj = (25 - percentRemaining) * 0.04f;
            Color current = new Color(1f,1f-adj, 0f);
            energyBar.GetComponent<SpriteRenderer>().color = current;
            guiText.color = current;
        }
    }

    private void GameOver()
    {
        // disable the potato gun
        GameObject.Find("Fire Point").SetActive(false);
    }
}
