using UnityEngine;
using System.Collections;

public class FlyBy : MonoBehaviour {
    public float speed = -3f;
    Vector3 startLocation;
    Vector3 endLocation;
    float offsetX = 21;

    void Awake()
    {
        startLocation = transform.position;
        endLocation = new Vector3(startLocation.x + offsetX, startLocation.y, startLocation.z);
        
    }

	// Use this for initialization
	void Start () {
        Initialize();
	}

    private void Initialize()
    {
        Vector3 tempLocation = transform.position;
        tempLocation = startLocation;
        transform.position = tempLocation;
        print("Stork initialzied");
    }
	
	// Update is called once per frame
	void Update () {
        // stop condition
        if (transform.localPosition.x > endLocation.x)
        {
            gameObject.SetActive(false);
        }
	    transform.Translate(speed * Time.deltaTime,0,0);
	}
}
