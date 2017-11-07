using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    
    public float waveSpeed;

    Rigidbody rb;
    Matrix4x4 localToWorld;
 

    // Use this for initialization
    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        localToWorld = transform.localToWorldMatrix;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] normals = mesh.normals;

        int i = 0;

        while (i < vertices.Length)
        {
            Vector3 worldPos = localToWorld.MultiplyPoint3x4(vertices[i]);

            vertices[i].Set(vertices[i].x, 1.55f * Mathf.Sin((Time.timeSinceLevelLoad + (worldPos.z / 10)) * waveSpeed) , vertices[i].z);

            i++;
        }

        mesh.vertices = vertices;

        mesh.RecalculateNormals();
    }
}
