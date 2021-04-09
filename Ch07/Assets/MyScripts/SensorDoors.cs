using UnityEngine;
using System.Collections;

public class SensorDoors : MonoBehaviour {
    public AnimationClip clipOpen;
    public AnimationClip clipClose;
    //public SmoothFollow follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider defender)
    {
        if (defender.gameObject.tag == "Player")
        {
            animation.Play(clipOpen.name);
            audio.Play();
        }
        //follow.distance = 1.15f;
        //follow.height = 0.5f;
    }

    void OnTriggerExit(Collider defender)
    {
        if (defender.gameObject.tag == "Player")
        {
            animation.Play(clipClose.name);
            audio.Play();
        }
        //follow.distance = 2.8f;
        //follow.height = 1.8f;
    }

}
