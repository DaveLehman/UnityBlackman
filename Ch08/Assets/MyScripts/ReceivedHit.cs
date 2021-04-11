using UnityEngine;
using System.Collections;

public class ReceivedHit : MonoBehaviour {
    public GameObject gameManager;
    public GameObject deadReplacement;
    public GameObject smokePlume;
    public int damage = 0;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Game Manager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        // kills bunny with a simple projectile
        //if(collision.transform.tag == "Ammo")
        //{
            // if this object was hit by something with the tag 'ammo', process its destruction
           // DestroyBun();
        //}
    }

    private void DestroyBun()
    {
        if(deadReplacement)
        {
            // get the dead replacement object's parent
            GameObject deadParent = deadReplacement.transform.parent.gameObject;
            // instantiate the dead replacement's parent at this object's transform
            GameObject dead = (GameObject)Instantiate(deadParent, transform.position, transform.rotation);
            // trigger its default animation
            deadReplacement.GetComponent<Animator>().Play("Jump Shrink");
            Destroy(dead, 1.0f);
            GameObject plume = (GameObject)Instantiate(smokePlume, transform.position, smokePlume.transform.rotation);
            Destroy(plume,5f);
        }
        Destroy(gameObject, 0.001f);
        gameManager.SendMessage("UpdateCount", -1, SendMessageOptions.DontRequireReceiver);
    }

    void Terminator(int newDamage)
    {
        damage += newDamage;
        //print("Object damage " + damage);
        if (damage > 10)
            DestroyBun();
    }
}
