using UnityEngine;
using System.Collections;

public class BasicPotatoLauncher : MonoBehaviour {

    public GameObject projectile;
    public float speed = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        // create a clone of the projectile at teh location & orientation of its parent
        GameObject potato = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

        // add some force
        potato.rigidbody.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
}
