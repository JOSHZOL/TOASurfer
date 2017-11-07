using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float PlayerSpeed;
    public float ArrivalDistance;

    public float waveSpeed;
    public int laneWidth;

    Rigidbody rb;

    int lane;
    bool restart = false;
    float restartTimer = 5.0f;

    double SpeedMultiplier;
    float previousXAxis;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        lane = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement between lanes

        if (previousXAxis == 0.0f && Input.GetAxis("Horizontal") > 0.0f && lane != 1)
        {
            lane++;
        }
        else if (previousXAxis == 0.0f && Input.GetAxis("Horizontal") < 0.0f && lane != -1)
        {
            lane--;
        }

        previousXAxis = Input.GetAxis("Horizontal");

        // Slow on Arrival to lane

        if (Mathf.Abs(rb.position.x - (float)(lane * laneWidth)) > ArrivalDistance)
        {
            SpeedMultiplier = 1.0f;
        }
        else
        {
            SpeedMultiplier = 1.0f * (Mathf.Abs(rb.position.x - (float)(lane * laneWidth)) / ArrivalDistance);
        }

        // Move to lane

        if ((lane * laneWidth) > rb.position.x)
        {
            rb.position = new Vector3(rb.position.x + ((float)(PlayerSpeed * SpeedMultiplier) * Time.deltaTime), rb.position.y, rb.position.z);
        }
        else if ((lane * laneWidth) < rb.position.x)
        {
            rb.position = new Vector3(rb.position.x - ((float)(PlayerSpeed * SpeedMultiplier) * Time.deltaTime), rb.position.y, rb.position.z);
        }

        // Change height for wave motion

        rb.position = new Vector3(rb.position.x, Mathf.Sin((Time.realtimeSinceStartup + (rb.position.z / 10)) * waveSpeed), rb.position.z);

        // Restart after collision

        if (restart == true)
        {
            restartTimer -= Time.deltaTime;
        }

        if (restartTimer <= 0.0f)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            restart = true;
            restartTimer = 2.0f;

            // Play object animation here

            // If needed delete object 
            Destroy(col.gameObject);

            // Play player animation here

            
        }
    }
}
