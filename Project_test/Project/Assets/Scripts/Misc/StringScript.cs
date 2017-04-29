/*Connects two objects with a string.*/
using UnityEngine;
using System.Collections;

public class StringScript : MonoBehaviour {
    public GameObject finishPoint;
    public Material stringMaterial;
    private LineRenderer string1;
	// Use this for initialization
	void Start () {
        string1 = gameObject.AddComponent<LineRenderer>();
        string1.material = stringMaterial;
        string1.SetWidth(0.2f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        string1.SetPosition(0, transform.position);
        string1.SetPosition(1, finishPoint.transform.position);
    }
}
