using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    public HeightScript heightScript;
    public TimerScript timerScript;
    public GravityScript gravityScript;
    private bool landed;
    private Rigidbody ballRB;
	void Start () {
        ballRB = GetComponent<Rigidbody>();
        ballRB.useGravity = false;
	}
	void Update () {
	}
    void OnCollisionEnter(Collision collisionInfo)
    {
        ballRB.useGravity = false;
        landed = true;
        timerScript.StopTimer();
        gravityScript.CalculateGravity();
    }
    void OnMouseDown()
    {
        if (landed)
        {
            transform.position = new Vector3(transform.position.x, heightScript.getHeight()+7.5f, transform.position.z);
            landed = false;
            timerScript.ResetTimer();
        }
        else
        {
            ballRB.useGravity = true;
            timerScript.StartTimer();
        }
    }
    public bool isLanded()
    {
        return landed;
    }
}
