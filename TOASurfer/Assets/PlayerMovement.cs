using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float PlayerSpeed;
    public float ArrivalDistance;

    Rigidbody rb;

    int lane;

    double SpeedMultiplier;
    float previousXAxis;
    
    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        lane = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (previousXAxis == 0.0f && Input.GetAxis("Horizontal") > 0.0f && lane != 1)
        {
            lane++;
        }
        else if (previousXAxis == 0.0f && Input.GetAxis("Horizontal") < 0.0f && lane != -1)
        {
            lane--;
        }

        previousXAxis = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rb.position.x - (float)(lane * 2)) > ArrivalDistance)
        {
            SpeedMultiplier = 1.0f;
        }
        else
        {
            SpeedMultiplier = 1.0f * (Mathf.Abs(rb.position.x - (float)(lane * 2)) / ArrivalDistance);
        }

        if ((lane * 2) > rb.position.x)
        {
            rb.position = new Vector3(rb.position.x + ((float)(PlayerSpeed * SpeedMultiplier) * Time.deltaTime), rb.position.y, rb.position.z);
        }
        else if ((lane * 2) < rb.position.x)
        {
            rb.position = new Vector3(rb.position.x - ((float)(PlayerSpeed * SpeedMultiplier) * Time.deltaTime), rb.position.y, rb.position.z);
        }

        rb.position = new Vector3(rb.position.x, Mathf.Sin(Time.realtimeSinceStartup * 3), rb.position.z);
    }
}
