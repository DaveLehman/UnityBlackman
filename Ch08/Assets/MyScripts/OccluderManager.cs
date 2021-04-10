using UnityEngine;
using System.Collections;

public class OccluderManager : MonoBehaviour {
    public bool state;              // active state to put the array elements into
    public GameObject[] newArea;    // array for the other side of the gate

	// Use this for initialization
	void Start () {
        //for (int i = 0; i < newArea.Length; i++)
            //print(newArea[i].name);
	}
	

    void OnTriggerEnter(Collider defender)
    {
        if (defender.gameObject.tag == "Player")
        {
            foreach(GameObject theElement in newArea)
            {
                theElement.SetActive(state);
            }
        }
    }

}
