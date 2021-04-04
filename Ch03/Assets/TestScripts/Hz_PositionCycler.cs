using UnityEngine;
using System.Collections;

public class Hz_PositionCycler : MonoBehaviour {
	
	public float minRange = 0.0f; 
	public float maxRange = 6.0f;
	public float speed = 0.1f;

	private float zPos; // starting position
	private float minPos;
	private float maxPos;

	
	void Start () {
	
		zPos = transform.position.z;
		
	}
	
	void Update () {
	
	}
	
	void FixedUpdate () {
	
		minPos = zPos + minRange; // calculate the target up position
		maxPos = zPos - maxRange; // calculate the target down position
		// use cosine to get smooth ease in/ease out motion
		float weight = Mathf.Cos((Time.time) * speed * 2f * Mathf.PI) * 0.5f + 0.5f;
		// apply the new z position
		float newPos = minPos * weight  + maxPos * (1-weight);
		transform.position = new Vector3(transform.position.x, transform.position.y, newPos);

	
	}
}