using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetMoveScript : MonoBehaviour
{
    public float NetSpeed;
    public float ArrivalDistance;

    public float waveSpeed;
    public int laneWidth;

    Rigidbody rb;

    int lane;
    int score;

    double SpeedMultiplier;

    // Use this for initialization
    void Start () {

        rb = gameObject.GetComponent<Rigidbody>();
        lane = 0;
        score = 0;
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            score += 1;
            Destroy(collision.gameObject);
        }
        else
        {
            // die
            SceneManager.LoadScene("Gameplay");
        }
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("X"))
        {
            lane = -1;
        }
        else if (Input.GetButtonDown("A"))
        {
            lane = 0;
        }
        else if (Input.GetButtonDown("B"))
        {
            lane = 1;
        }

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
            rb.position = new Vector3(rb.position.x + ((float)(NetSpeed * SpeedMultiplier) * Time.deltaTime), rb.position.y, rb.position.z);
        }
        else if ((lane * laneWidth) < rb.position.x)
        {
            rb.position = new Vector3(rb.position.x - ((float)(NetSpeed * SpeedMultiplier) * Time.deltaTime), rb.position.y, rb.position.z);
        }

        // Change height for wave motion

        rb.position = new Vector3(rb.position.x, 1.55f * Mathf.Sin((Time.realtimeSinceStartup + (rb.position.z / 10)) * waveSpeed), rb.position.z);
    }

}
