using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    public Sprite Highlighted;
    public Sprite Unhighlighted;
    public int Selected = 0;
    SpriteRenderer spSpriteRenderer;

	// Use this for initialization
	void Start () {
        spSpriteRenderer = GetComponent<SpriteRenderer>();
        spSpriteRenderer.sprite = Unhighlighted;
    }
	
	// Update is called once per frame
	void Update () {

		if (Selected == 0)
        {
            spSpriteRenderer.sprite = Unhighlighted;
        }
        else
        {
            spSpriteRenderer.sprite = Highlighted;
        }
	}

    private void OnMouseEnter()
    {
        spSpriteRenderer.sprite = Highlighted;
    }

    private void OnMouseExit()
    {
        spSpriteRenderer.sprite = Unhighlighted;
    }

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
