using UnityEngine;
using System.Collections;

public class PotatoLauncher : MonoBehaviour {
    public GameObject projectile;
    public float speed = 20f;
    /* Basic Launcher spewed way too many projectiles -- this version uses a timer to specify when the next projectile is
     available */
    /* We also have a Projectile script that will destroy the object a few seconds after creation so they don't hang around too long */
    public float loadRate = 0.5f;   // how often a new projectile can be fired
    float timeRemaining;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // timeRemaining is zero first time through, so projectile is immediately available. After that you have to wait
        timeRemaining -= Time.deltaTime;
	    if(Input.GetButton("Fire1") && timeRemaining <= 0)
        {
            timeRemaining = loadRate;
            ShootProjectile();
        }
	}

    private void ShootProjectile()
    {
        // create a clone of the projectile at teh location & orientation of its parent
        GameObject potato = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

        // add some force
        potato.rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        audio.Play();
    }
}
