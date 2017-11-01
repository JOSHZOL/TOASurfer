using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {

    Rigidbody rb;

    public float waveSpeed;

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //rb.position = new Vector3(rb.position.x, Mathf.Sin((Time.realtimeSinceStartup + (rb.position.z / 10)) * 3) - 0.5f, rb.position.z);

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        int i = 0;

        while (i < vertices.Length)
        {
            vertices[i].Set(vertices[i].x, 1.55f * Mathf.Sin((Time.realtimeSinceStartup + (vertices[i].z / 4)) * waveSpeed + 15.5f) , vertices[i].z);

            i++;
        }

        mesh.vertices = vertices;

        mesh.RecalculateNormals();
    }
}
