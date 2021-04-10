using UnityEngine;
using System.Collections;

public class ReceivedHit : MonoBehaviour {
    public GameObject gameManager;
    public GameObject deadReplacement;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("Game Manager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ammo")
        {
            // if this object was hit by something with the tag 'ammo', process its destruction
            DestroyBun();
        }
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
        }
        Destroy(gameObject, 0.001f);
        gameManager.SendMessage("UpdateCount", -1, SendMessageOptions.DontRequireReceiver);
    }
}
