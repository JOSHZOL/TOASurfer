using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GotoMenu : MonoBehaviour {

    float fDelay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        fDelay += Time.deltaTime;

        if (fDelay > 8.5f)
        {
            SceneManager.LoadScene("Menu");
        }
	}
}
