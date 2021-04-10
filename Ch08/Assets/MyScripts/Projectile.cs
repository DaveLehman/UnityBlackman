using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    // automatically destroy the projectile 3 seconds after creation
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // projectile is destroyed sooner if it hits something
    void OnCollisionEnter()
    {
        Destroy(gameObject, 2f);
    }
}
