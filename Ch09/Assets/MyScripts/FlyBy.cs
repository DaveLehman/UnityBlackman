using UnityEngine;
using System.Collections;

public class FlyBy : MonoBehaviour {
    public float speed = -500f;
        
        Vector3 startLocation;
        Vector3 endLocation;
        float startOffset = 500f;
        float endOffset = -3000f;

    void Awake()
    {
        startLocation = transform.position; // store the starting location
        startLocation.x = startLocation.x + startOffset;
        transform.Translate(startLocation);
        print("start is " + startLocation.x.ToString() + "," + startLocation.y.ToString()+", "+startLocation.z);
        endLocation = new Vector3(startLocation.x + endOffset, startLocation.y, startLocation.z);
    }

	// Use this for initialization
	void Start () {
        //Initialize();
	}

    private void Initialize()
    {
        Vector3 tempLocation = transform.position;
        tempLocation = startLocation;
        transform.position = tempLocation;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.localPosition.x < endLocation.x)
        {
            // deactivate
            gameObject.SetActive(false);
        }
	}
}
