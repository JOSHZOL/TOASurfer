using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour {

    float Origin;
    bool finished = false;

    public float ObjectSpeed;
    public float Offset;

    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Origin = rb.position.z;
        rb.position = new Vector3(rb.position.x, rb.position.y, Origin - Offset);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rb.position.z < Origin && !finished)
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + (ObjectSpeed * Time.deltaTime));
        }
        else if (!finished)
        {
            finished = true;
        }
    }
}
