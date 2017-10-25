using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Rigidbody playerRb;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(playerRb.position.x / 2, transform.position.y, transform.position.z);
	}
}
