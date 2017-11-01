using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementWaves : MonoBehaviour {

    public float waveSpeed;
    public float ObjectSpeed;

    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + (ObjectSpeed * Time.deltaTime));
        
        //rb.position = new Vector3(rb.position.x, 1.55f * Mathf.Sin((Time.realtimeSinceStartup) * waveSpeed + rb.position.z + 0.5f) - 0.8f, rb.position.z);

        rb.velocity = new Vector3(0, 0, ObjectSpeed);
    }
}
