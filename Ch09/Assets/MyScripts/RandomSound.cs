using UnityEngine;
using System.Collections;

public class RandomSound : MonoBehaviour {
    public AudioClip[] SoundFX;
    public AudioSource thisSource;
	// Use this for initialization
	void Start () {
	int num = Random.Range(0,SoundFX.Length);
    if (thisSource != null)
        thisSource.audio.PlayOneShot(SoundFX[num]);
    else
        print("No source");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
