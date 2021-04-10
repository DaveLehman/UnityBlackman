using UnityEngine;
using System.Collections;

public class SimpleCharacterController : MonoBehaviour {
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (animator)
        {
            float v = Input.GetAxis("Vertical");
            animator.SetFloat("Input V", v);
            //print(v);
        }
	}
}
