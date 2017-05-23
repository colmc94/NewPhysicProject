using UnityEngine;
using System.Collections;

public class RotateEarth : MonoBehaviour {
    private float x;
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(.05f,.5f, .1f);
        transform.position= new Vector3(transform.position.x-0.015f, transform.position.y + 0.01f, transform.position.z);
        if (transform.position.y >= 9)
        {
            transform.position = startPosition;
        }
    }
}
