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

    public bool Gameplay;

    Rigidbody rb;
    Animator ani;

    public GameObject Canvus;

    int lane;
    public bool restart = false;
    float restartTimer = 5.0f;

    bool pause;

    double SpeedMultiplier;
    float previousXAxis;

    bool animationPlay;
    float animationTimer;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        ani = gameObject.GetComponentInChildren<Animator>();

        if (Gameplay)
        Canvus.SetActive(false);

        lane = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement between lanes

        if (animationPlay)
        {
            animationTimer -= Time.deltaTime;
        }

        if (animationPlay && animationTimer < 0.0f)
        {
            animationPlay = false;
            ani.SetBool("Right", false);
            ani.SetBool("Left", false);

            float positionOfAni = (Time.timeSinceLevelLoad / 2) - (int)(Time.timeSinceLevelLoad / 2);
            ani.Play("Idle", -1, positionOfAni);
        }
           
        if (!restart)
        {
            if (previousXAxis == 0.0f && Input.GetAxis("Horizontal") > 0.0f && lane != 1 && Gameplay)
            {
                lane++;

                animationPlay = true;
                animationTimer = 0.3f;
                ani.SetBool("Right", true);
            }
            else if (previousXAxis == 0.0f && Input.GetAxis("Horizontal") < 0.0f && lane != -1 && Gameplay)
            {
                lane--;

                animationPlay = true;
                animationTimer = 0.3f;
                ani.SetBool("Left", true);
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

            rb.position = new Vector3(rb.position.x, 1.55f * Mathf.Sin((Time.timeSinceLevelLoad + (rb.position.z / 10)) * waveSpeed) - 0.2f, rb.position.z);
        }

        // Restart after collision

        if (restart == true)
        {
            restartTimer -= Time.deltaTime;
        }

        if (restartTimer <= 0.0f)
        {
            SceneManager.LoadScene("Gameplay");
        }

        if ((Input.GetKeyDown("p") || Input.GetButtonDown("Pause")) && !pause && Gameplay)
        {
            Canvus.SetActive(true);

            Time.timeScale = 0.0f;
            pause = true;
        }
        else if((Input.GetKeyDown("p") || Input.GetButtonDown("Pause")) && pause && Gameplay)
        {
            Canvus.SetActive(false);

            Time.timeScale = 1.0f;
            pause = false;
        }

        if (pause && Input.GetButtonDown("A") && Gameplay)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Menu");
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle" && !restart)
        {
            restart = true;
            restartTimer = 2.0f;

            // Play object animation here

            // If needed delete object 
            Destroy(col.gameObject);

            ani.SetBool("Death", true);
        }
    }
}
