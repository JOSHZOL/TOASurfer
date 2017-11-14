using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerNavScript : MonoBehaviour {

    public GameObject Play;
    public GameObject Tutorial;
    public GameObject Settings;
    public GameObject Credits;
    public GameObject Quit;

    int index = 1;
    float previousXAxis = 0.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Vertical") > 0.0f && index != 1 && previousXAxis == 0.0f)
        {
            index--;
        }
        else if (Input.GetAxis("Vertical") < 0.0f && index != 5 && previousXAxis == 0.0f)
        {
            index++;
        }

        previousXAxis = Input.GetAxis("Vertical");


        if (index == 1)
        {
            if (Input.GetButtonDown("A") || Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Gameplay");
            }
            Play.GetComponent<PlayButton>().Selected = 1;
            Tutorial.GetComponent<HowToPlayButton>().Selected = 0;
        }
        else if (index == 2)
        {
            if (Input.GetButtonDown("A") || Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Tutorial");
            }
            Play.GetComponent<PlayButton>().Selected = 0;
            Tutorial.GetComponent<HowToPlayButton>().Selected = 1;
            Settings.GetComponent<SettingsButton>().Selected = 0;
        }
        else if (index == 3)
        {
            if (Input.GetButtonDown("A") || Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Settings");
            }
            Tutorial.GetComponent<HowToPlayButton>().Selected = 0;
            Settings.GetComponent<SettingsButton>().Selected = 1;
            Credits.GetComponent<CreditScript>().Selected = 0;

        }
        else if (index == 4)
        {
            if (Input.GetButtonDown("A") || Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Credits");
            }
            Settings.GetComponent<SettingsButton>().Selected = 0;
            Credits.GetComponent<CreditScript>().Selected = 1;
            Quit.GetComponent<QuitButton>().Selected = 0;
        }
        else if (index == 5)
        {
            if (Input.GetButtonDown("A") || Input.GetKeyDown("space"))
            {
                Application.Quit();
            }
            Credits.GetComponent<CreditScript>().Selected = 0;
            Quit.GetComponent<QuitButton>().Selected = 1;
        }
    }
}
