using UnityEngine;
using System.Collections;

public class ColliderTests : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision theVictim)
	{
		//print ("Ouch");
		print (theVictim.gameObject.name + " got hit");
	}
}
