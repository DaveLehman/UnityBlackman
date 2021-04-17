using UnityEngine;
using System.Collections;

public class SpawnBunnies : MonoBehaviour {
    GameObject gameManager;
    public Transform bunHolder;     // parent for all the bunnies
    public GameObject zombieBunny;  //the prefab
    public Transform dropZone;      // where they go

    public Animator beak;

    public int litterSize = 8;      // base number of new bunnies to add - this will be nodified, see below
    public float reproRate = 12f;    // seconds until we get more bunnies
    internal bool canReproduce = true;    // set this to false when no more bunnies
    public int currentBunCount = 0;
    float minX;
    float maxX;
    float minZ;
    float maxZ;

	// Use this for initialization
	void Start () {
        // set our bounding box
        minX = dropZone.position.x - dropZone.localScale.x / 2;
        maxX = dropZone.position.x + dropZone.localScale.x / 2;
        minZ = dropZone.position.z - dropZone.localScale.z / 2;
        maxZ = dropZone.position.z + dropZone.localScale.z / 2;

        // first drop is triple litterSize
        int initialLitterSize = litterSize * 3;

        gameManager = GameObject.Find("Game Manager");

        PopulateGardenBunnies(initialLitterSize);

        float tempRate = reproRate * 2; // alow extra time after initial drop
        StartCoroutine(StartReproducing(tempRate));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void PopulateGardenBunnies(int count)
    {
        if (!canReproduce) return;

        // actual number of bunnies will be betwee .75 and 1 times the littersize
        count = Random.Range(count * 3 / 4, count + 1);
        //print("Dropping " + count + " zombie bunnes...");
        for (int i = 0; i < count; i++ )
        {
            // random drop location for each bunny
            GameObject zBunny = (GameObject)Instantiate(zombieBunny, new Vector3(Random.Range(minX, maxX), 2.0f, Random.Range(minZ, maxZ)), Quaternion.identity);
            gameManager.SendMessage("UpdateCount", 1, SendMessageOptions.DontRequireReceiver);
            // at this point they all point the same way and run their animations in unison. Kinda creepy.

            // rotate them somewhere else
            Vector3 rot = zBunny.transform.localEulerAngles;
            rot.y = Random.Range(1, 361);
            zBunny.transform.localEulerAngles = rot;

            // now randomize the animation starting point
            zBunny.GetComponent<Animator>().Play("Bunny Eat", 0, Random.Range(0.0f, 1.0f));
            zBunny.transform.parent = bunHolder;
        }
            
    }

    IEnumerator StartReproducing(float minTime)
    {
        // wait this much time before going on
        float adjustedTime = Random.Range(minTime, minTime + 5);
        // having waited, make more bunnies
        //yield return new WaitForSeconds(adjustedTime); // original call, let's add drama with a stork sound
        yield return new WaitForSeconds(adjustedTime-3f);        
        audio.Play();
        yield return new WaitForSeconds(Random.Range(1f,2f));
        beak.SetBool("Cue the Beak Open", true);
        PopulateGardenBunnies(litterSize);
        // and start the Coroutine again to minTime, but only if there any left to reproduce
        if (canReproduce) StartCoroutine(StartReproducing(reproRate));
    }

}
