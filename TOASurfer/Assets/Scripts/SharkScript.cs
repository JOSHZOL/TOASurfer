using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkScript : MonoBehaviour {

    int PlayerScore;
    float Origin;
    public float Speed;

    public bool StartGame = false;

    Rigidbody rb;
    public GameObject net;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Origin = 62;
    }
	
	// Update is called once per frame
	void Update () {
        PlayerScore = net.GetComponent<NetMoveScript>().score;

        if (rb.position.z >= 50)
        {
            StartGame = true;
        }

        if (rb.position.z > Origin - (PlayerScore * 0.76))
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + (Speed * Time.deltaTime));
        }
    }
}

