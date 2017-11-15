using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayButton : MonoBehaviour {

    public Sprite Highlighted;
    public Sprite Unhighlighted;
    public int Selected = 0;
    SpriteRenderer srSpriteRenderer;
   
    // Use this for initialization
    void Start () {
        srSpriteRenderer = GetComponent<SpriteRenderer>();
        srSpriteRenderer.sprite = Unhighlighted;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Selected == 0)
        {
            srSpriteRenderer.sprite = Unhighlighted;
            transform.localScale = new Vector3(0.24f, 0.24f, 0.24f);
        }
        else
        {
            srSpriteRenderer.sprite = Highlighted;
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }
}
