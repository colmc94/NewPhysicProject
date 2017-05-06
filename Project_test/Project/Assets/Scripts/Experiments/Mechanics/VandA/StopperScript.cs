using UnityEngine;
using System.Collections;

public class StopperScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("collision Enter");
    }
    void OnTriggerEnter(Collider otherInfo)
    {
        Debug.Log("triggerEnter");
    }
}
