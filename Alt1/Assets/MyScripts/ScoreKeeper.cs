using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    public int currentBunCount = 0;
    public Text bunnyCounterText;
    public SpawnBunnies spawner;

    int killCount = 0;      // player hits
    int hitsRequired = 10;  // hits required for reward
    public PotatoLauncher launcher;

	// Use this for initialization
	void Start () {
        currentBunCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateCount(int adjustment)
    {
        {
            currentBunCount += adjustment;
            //print("new count " + currentBunCount);
            bunnyCounterText.text = currentBunCount.ToString();

            if (currentBunCount == 0)
            {
                GardenSecure();
                return;
            }

            if(currentBunCount == 1 || currentBunCount == 0)
            {
                // stop the population explosion
                spawner.canReproduce = false;
            }
            else
            {
                spawner.canReproduce = true;
            }



            if (launcher.loadRate < 0.2f) return;
            // manage player rewards
            if (adjustment == -1)
            {
                killCount++;
                int remainder = killCount % hitsRequired;
                //print("remainder = " + remainder + ", " + killCount + " dead");
                if (remainder == 0 && killCount > 0)
                {
                    launcher.SendMessage("RewardTime", SendMessageOptions.DontRequireReceiver);
                    //print("Reward time!");
                    //print("current rate: " + launcher.loadRate);
                }
            }
                
        }
    }

    private void GardenSecure()
    {
        // if Game Over
        // if more gardens
        // if more levels
    }
}
