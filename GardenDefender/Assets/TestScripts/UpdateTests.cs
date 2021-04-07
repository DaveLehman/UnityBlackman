using UnityEngine;
using System.Collections;

public class UpdateTests : MonoBehaviour {
	public float SpeedPerSecond = 0.5f;
	bool allClear = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// no control over speed
		//transform.Translate (Vector3.forward);
		// one tenth of a unit per frame
		//transform.Translate (Vector3.forward *.01f);
		// one unit per second
		//transform.Translate (Vector3.forward * Time.deltaTime);
		// one unit per second times our speed multiplier

		if (transform.localEulerAngles.y < 270) {
			transform.Rotate (Vector3.up * Time.deltaTime * 20f, Space.World);
		}
		if (transform.localEulerAngles.y > 270) {
			Vector3 rot = transform.localEulerAngles;
			rot.y = 270f;
			transform.localEulerAngles = rot;
			allClear = true;
		}
		if (allClear) {
			transform.Translate (Vector3.left * Time.deltaTime * SpeedPerSecond);
		}
	}
}
