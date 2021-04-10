using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
    public int currentBunCount = 0;
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
            print("new count " + currentBunCount);
        }
    }
}
