using UnityEngine;
using System.Collections;

public class SensorDoors : MonoBehaviour {
    public AnimationClip clipOpen;
    public AnimationClip clipClose;

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
    }

    void OnTriggerExit(Collider defender)
    {
        if (defender.gameObject.tag == "Player")
        {
            animation.Play(clipClose.name);
            audio.Play();
        }
    }

}
