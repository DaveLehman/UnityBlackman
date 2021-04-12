using UnityEngine;
using System.Collections;

public class PlantRemover : MonoBehaviour {
    public int hardiness = 1;   // amount of damage to destroy the plant
    public int damage = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Terminator(int newDamage)
    {
        damage += newDamage;
        if (damage > hardiness) Destroy(gameObject);
    }
}
