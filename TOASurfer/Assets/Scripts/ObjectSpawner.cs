using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public float spawnDelay;
    public GameObject floatingObject;

    public GameObject Shark;

    float spawnTimer;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && Shark.GetComponent<SharkScript>().StartGame)
        {
            spawnTimer = spawnDelay;

            Instantiate(floatingObject);

            floatingObject.transform.position = new Vector3(Random.Range(-1, 2) * 3, -3, Shark.GetComponent<Rigidbody>().position.z - 5);
        }
	}
}
