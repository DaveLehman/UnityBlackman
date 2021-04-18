using UnityEngine;
using System.Collections;

public class BundleManager : MonoBehaviour {
    public GameObject stork;    // the Stork Group object
    Vector3 startLocation;      // the bundle's original location
    public Animator animator;   // bundle's animator
    GameObject[] buns2d;


    void Awake()
    {
        startLocation = transform.localPosition;
        buns2d = GameObject.FindGameObjectsWithTag("Buns2D");
    }

	// Use this for initialization
	void Start () {
        Initialize();
	}

    private void Initialize()
    {
        animator.Play("Bundle Carry");
    }

    void OnCollisionEnter2D()
    {
        print("Collision -- number of baby bunnies is " + buns2d.Length);
        foreach(GameObject bun in buns2d)
        {
            bun.GetComponent<BabyZBHandler>().Escape();
        }
        print("Opening bundle");
        animator.Play("Bundle Open");
        StartCoroutine(Deactivator());
    }
	
    IEnumerator Deactivator()
    {
        print("bundle deactivator");
        
        // turn off the physics
        rigidbody2D.isKinematic = true;
        yield return new WaitForSeconds(3.5f);
        // add the bundle back into the stork group
        transform.parent = stork.transform;
        // reset the start position
        Vector3 tempLocation = transform.position;
        tempLocation = startLocation;
        transform.localPosition = tempLocation;
        // need to restart the Carry Bundle animation
        animator.Play("Bundle Carry");

    }


	// Update is called once per frame
	void Update () {
	
	}
}
