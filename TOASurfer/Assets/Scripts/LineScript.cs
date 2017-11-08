using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour {

    LineRenderer line;

    public GameObject hand;
    public GameObject net;

    // Use this for initialization
    void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        line.SetPosition(0, hand.transform.position);
        line.SetPosition(1, net.transform.position);
    }
}
