using UnityEngine;
using System.Collections;

public class BallPedulumScript : MonoBehaviour {
    public TimerScript timer;
    private Rigidbody ballRB;
    private bool stopped;
    private int occelationsCount;
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        ballRB = GetComponent<Rigidbody>();
        stopped = true;
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (occelationsCount == 60)
        {
            timer.StopTimer();
            ResetPosition();
        }
        if (stopped)
        {
            ResetPosition();
        }
	}
    void OnMouseDown()
    {
        if (stopped)
        {
            Debug.Log("Mouse Down");
            ballRB.AddForce(100000, 0, 0);
            stopped = false;
            timer.StartTimer();
            occelationsCount = 0;
        }
    }
    void OnTriggerEnter()
    {
        occelationsCount++;
        Debug.Log("Count = "+occelationsCount/2);
    }
    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        ballRB.velocity = new Vector3(0,0,0);
        stopped = true;
    }
    public Rigidbody GetRigidBody()
    {
        return ballRB;
    }
}
