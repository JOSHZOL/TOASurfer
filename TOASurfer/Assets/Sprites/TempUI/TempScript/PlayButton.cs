using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    public Sprite Highlighted;
    public Sprite Unhighlighted;

    public int Selected = 0;

    SpriteRenderer srSpriteRenderer;
  
    // Use this for initialization

    void Start ()
    {
        srSpriteRenderer = GetComponent<SpriteRenderer>();
        srSpriteRenderer.sprite = Highlighted;
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

    public void OnMouseEnter()
    {
        srSpriteRenderer.sprite = Highlighted;
    }

    public void OnMouseExit()
    {
        srSpriteRenderer.sprite = Unhighlighted;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
