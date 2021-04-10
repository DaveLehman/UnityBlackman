using UnityEngine;
using System.Collections;

public class ReceivedHit : MonoBehaviour {
    public GameObject gameManager;

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
        Destroy(gameObject, 0.2f);
        gameManager.SendMessage("UpdateCount", -1, SendMessageOptions.DontRequireReceiver);
    }
}
