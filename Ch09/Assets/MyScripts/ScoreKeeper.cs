using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public int currentBunCount = 0;
    public Text bunnyCounterDisplay;    // the text on the Canvas
    public PotatoLauncher launcher;     // the script attached to the Gnome's arm
    public SpawnBunnies bunnySpawner;   // the script attached to the Zombie Spawn Manager object
    int killCount = 0;  // player hits
    int hitsRequired = 10;
	// Use this for initialization
	void Start () {
        currentBunCount = 0;
        print("ScoreKeeper running");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateCount(int adjustment)
    {
        {
            currentBunCount += adjustment;
            print("new count " + currentBunCount);
            bunnyCounterDisplay.text = currentBunCount.ToString();

            if (currentBunCount == 0)
            { // garden secure
                GardenSecure();
                return;
            }


            //if (currentBunCount == 10)
            //{ // stop the population explosion!
                //print("Stopping battery drain and bunny population");
                // stop the battery drain - the threat is almost neutralized
                //GameObject.Find("Battery Life Text").GetComponent<BatteryHealth>().trackingBattery = false;

                //bunnySpawner.canReproduce = false;
            //}

            // put a floor on how low loadRate can go
            if (launcher.loadRate < 0.2f) return;
            // manage player rewards
            if(adjustment == -1)
            {
                killCount++;
                int remainder = killCount % hitsRequired;
                //print("remainder = " + remainder + ", " + killCount + " dead");
                if(remainder == 0 && killCount > 0)
                {
                    print("Reward Time!");
                    launcher.SendMessage("RewardTime", SendMessageOptions.DontRequireReceiver);
                    //print("current rate: " + launcher.loadRate);
                }
            }
        }
    }

    private void GardenSecure()
    {
        print("Garden Secure");
        // if game over

        // if more gardens

        // if more levels

    }
}
