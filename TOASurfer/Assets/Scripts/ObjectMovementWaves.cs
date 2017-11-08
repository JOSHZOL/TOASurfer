using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementWaves : MonoBehaviour {

    public float waveSpeed;
    public float ObjectSpeed;
    public float offset;
    public float waveSize = 1.55f;
    public float rotationMultiplier = 20;
    public float rotationY = 0;
    public float rotationZ = 0;

    Rigidbody rb;

    Quaternion Rotation;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z + (ObjectSpeed * Time.deltaTime));

        rb.position = new Vector3(rb.position.x, waveSize * Mathf.Sin((Time.timeSinceLevelLoad + (rb.position.z / 10)) * waveSpeed) + offset, rb.position.z);

        Rotation.eulerAngles = new Vector3(Mathf.Cos((Time.timeSinceLevelLoad + (rb.position.z / 10)) * waveSpeed) * rotationMultiplier, rotationY, rotationZ);

        rb.rotation = Rotation;

        if (rb.position.z < -5)
        {
            Destroy(gameObject);
        }
    }

    
}
