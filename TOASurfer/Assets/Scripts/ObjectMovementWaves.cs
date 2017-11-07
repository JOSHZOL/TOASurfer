using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementWaves : MonoBehaviour {

    public float waveSpeed;
    public float ObjectSpeed;

    public float offset;

    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + (ObjectSpeed * Time.deltaTime));

        rb.position = new Vector3(rb.position.x, 1.55f * Mathf.Sin((Time.timeSinceLevelLoad + (rb.position.z / 10)) * waveSpeed) + offset, rb.position.z);

        if (rb.position.z < -5)
        {
            Destroy(gameObject);
        }
    }

    
}
