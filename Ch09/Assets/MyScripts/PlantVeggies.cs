using UnityEngine;
using System.Collections;

public class PlantVeggies : MonoBehaviour {
    public GameObject veggie;   // prefab of the plant
    public Transform plantHolder;   // parent, used for occlusion
    float minX;
    float minZ;
    public bool rotate;         // flag to rotate the rows to match the bed
    public int rows = 6;
    public int columns = 6;
    public int percentMissing = 20;
    float spacingX;
    float spacingZ;

	// Use this for initialization
	void Start () {
        // do all the math to get the grid numbers
        minX = transform.position.x - transform.localScale.x / 2;
        minZ = transform.position.z - transform.localScale.z / 2;
        spacingX = transform.localScale.x / rows;
        spacingZ = transform.localScale.z / columns;

        PopulateBed();
	
	}

    private void PopulateBed()
    {
        float y = transform.position.y; //ground level
        for(int x = 0; x < columns; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                Vector3 pos = new Vector3(x * spacingX + minX + spacingX/2, y, z * spacingZ + minZ+spacingZ/2);
                // want 20 percent of plants to be missing -- after all they're being attacked by zombie bunnies
                int rPercent = Random.Range(1, 101);
                if (rPercent > percentMissing)
                {
                    GameObject newVeggie = (GameObject)Instantiate(veggie, pos, Quaternion.identity);

                    // do a random rotation
                    Vector3 rot = newVeggie.transform.localEulerAngles;
                    rot.y = Random.Range(1, 361);
                    newVeggie.transform.localEulerAngles = rot;
                    // do a random scaling
                    Vector3 scale = newVeggie.transform.localScale;
                    float rScale = Random.Range(0.75f, 1.2f);
                    scale = new Vector3(rScale, rScale, rScale);
                    newVeggie.transform.localScale = scale;

                    newVeggie.transform.parent = plantHolder;
                }

            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
