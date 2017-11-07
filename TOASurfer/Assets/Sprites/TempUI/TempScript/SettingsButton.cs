using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour {

    SpriteRenderer srSpriteRenderer;

    public Sprite Highlighted;
    public Sprite Unhighlighted;
    public int Selected = 0;
    // Use this for initialization
    void Start () {
        srSpriteRenderer = GetComponent<SpriteRenderer>();
        srSpriteRenderer.sprite = Unhighlighted;
    }
	
	// Update is called once per frame
	void Update () {

         
		if (Selected == 0)
        {
            srSpriteRenderer.sprite = Unhighlighted;
        }
        else
        {
            srSpriteRenderer.sprite = Highlighted;
        }
	}

    private void OnMouseEnter()
    {
        srSpriteRenderer.sprite = Highlighted;
    }

    private void OnMouseExit()
    {
        srSpriteRenderer.sprite = Unhighlighted;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Settings");
    }
}
