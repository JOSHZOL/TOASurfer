using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkLineScript : MonoBehaviour {

    LineRenderer line;

    public GameObject hand;
    public GameObject net;

    // Use this for initialization
    void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        line.SetPosition(0, hand.transform.position);
        line.SetPosition(4, net.transform.position);

        lineUpdate(2, 0, 4, 20);
        lineUpdate(1, 0, 2, 10);
        lineUpdate(3, 2, 4, 30);
    }

    void lineUpdate(int _currentPoint, int _start, int _end, float _speed)
    {
        if (line.GetPosition(_currentPoint).x < (line.GetPosition(_end).x + (Mathf.Abs(line.GetPosition(_start).x - line.GetPosition(_end).x) / 2)))
        {
            line.SetPosition(_currentPoint, new Vector3(line.GetPosition(_currentPoint).x + (_speed * Time.deltaTime), (line.GetPosition(_end).y - (Mathf.Abs(line.GetPosition(_start).y - line.GetPosition(_end).y) / 2)), (line.GetPosition(_end).z - (Mathf.Abs(line.GetPosition(_start).z - line.GetPosition(_end).z) / 2))));
        }

        if (line.GetPosition(_currentPoint).x > (line.GetPosition(_end).x - (Mathf.Abs(line.GetPosition(_start).x - line.GetPosition(_end).x) / 2)))
        {
            line.SetPosition(_currentPoint, new Vector3(line.GetPosition(_currentPoint).x - (_speed * Time.deltaTime), (line.GetPosition(_end).y - (Mathf.Abs(line.GetPosition(_start).y - line.GetPosition(_end).y) / 2)), (line.GetPosition(_end).z - (Mathf.Abs(line.GetPosition(_start).z - line.GetPosition(_end).z) / 2))));
        }
    }
}
