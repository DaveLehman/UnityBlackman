using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    public GameObject explosion;

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
        Vector3 explosionPosition = transform.position;
        Instantiate(explosion, explosionPosition, Quaternion.identity);
        Destroy(gameObject);
    }
}
