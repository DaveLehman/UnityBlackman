using UnityEngine;
using System.Collections;

public class Projectile2 : MonoBehaviour {
    //Simple projectile hits a single object
    // Now that we have an elaborate explosion, it's more logical to work off proximity than direct hits
    // original version triggered the explosion based on the hit point. If we did sparks or shrapnel,
    // we'd want to orient the animation at the normal to the surface that was hit
    public GameObject explosion;
    // now we need to collect nearby objects -- these values are done here, and have nothing to do with what you see on the screen
    public float explosionTime = 1f;        // how long effect will last
    public float explosionRadius = 0.5f;    
    public float explosionPower = 50f;      // force to be applied to nearby objects
    public int damage = 10;                 // not yet used but ready for HP system

    // automatically destroy the projectile 3 seconds after creation
	// Use this for initialization
	void Start () {
        Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //void OnCollisionEnter()
   // {
        // simple version
        //Vector3 explosionPosition = transform.position;
        //Instantiate(explosion, explosionPosition, Quaternion.identity);
        //Destroy(gameObject);
    //}

    void OnCollisionEnter(Collision collision)
    {
        // get the contact point
        ContactPoint contact = collision.contacts[0]; // array of contact cuz you can't assume only single item hit
        // calculate the normal of the contact point
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        // Instatioate an explosion at that point, using its normal as the orientation
        Instantiate(explosion, contact.point, rotation);
        // find all nearby colliders
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach( Collider hit in hitColliders )
        {
            // Tell the rigidbody or any other script attached to it that the object was hit
            // zombies now have a 1 in 3 chance of disappearing on the first hit
            hit.gameObject.SendMessage("Terminator", damage + Random.Range(0,2), SendMessageOptions.DontRequireReceiver);
            if (hit.rigidbody)
            {
                hit.rigidbody.AddExplosionForce(explosionPower, transform.position, explosionRadius);
            }
        }
        // get rid of the potato
        Destroy(gameObject);
    }
}
