using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public float spawnDelay;
    public GameObject floatingObject;

    float spawnTimer;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < 5; i++)
        {
            var newObject = Instantiate(floatingObject);
            newObject.transform.position = new Vector3(Random.Range(-1, 2) * 3, -3, 25 + (i * 5));
        }

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            spawnTimer = spawnDelay;

            Instantiate(floatingObject);

            floatingObject.transform.position = new Vector3(Random.Range(-1, 2) * 3, -3, 25 + (5 * 5));
        }
	}
}
