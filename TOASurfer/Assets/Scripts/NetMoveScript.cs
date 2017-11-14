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

    public GameObject Player;
    public GameObject spiritBall;

    public ParticleSystem particles;

    Quaternion Rotation;

    float lane;
    public int score;

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

            particles.Play();
        }
        else if (collision.gameObject.tag == "Shark")
        {
            // Victory Screen
            SceneManager.LoadScene("Menu");
        }
        else
        {
            // die
            SceneManager.LoadScene("Gameplay");
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        if (!Player.GetComponent<PlayerMovement>().restart)
        {
            lane = (Player.transform.position.x / laneWidth) + (Input.GetAxis("Horizontal2"));

            if (lane > 1)
            {
                lane = 1;
            }
            else if (lane < -1)
            {
                lane = -1;
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

            spiritBall.transform.localScale = new Vector3(score * 2, score * 2, score * 2);
        }
        else
        {
            rb.position = new Vector3(rb.position.x, rb.position.y, rb.position.z - (5 * Time.deltaTime));
        }

        // Change height for wave motion

        rb.position = new Vector3(rb.position.x, 1.55f * Mathf.Sin((Time.timeSinceLevelLoad + (rb.position.z / 10)) * waveSpeed) - 1, rb.position.z);

        Rotation.eulerAngles = new Vector3(Mathf.Cos((Time.timeSinceLevelLoad + (rb.position.z / 10)) * waveSpeed) * -20, Input.GetAxis("Horizontal2") * -25, 0);

        rb.rotation = Rotation;
    }

}
