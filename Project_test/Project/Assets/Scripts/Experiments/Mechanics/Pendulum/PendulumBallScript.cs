using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumBallScript : MonoBehaviour {
    public PendulumHeightScript pendulumHeightScript;
    public PendulumScript pendulumScript;
    public TimerScript timer;
    public Text occelationsText;
    private Rigidbody ballRB;
    private bool stopped;
    private int occelationsCount;
    private Vector3 startPosition;
	// Use this for initialization
	void Start () {
        ballRB = GetComponent<Rigidbody>();
        stopped = true;
        startPosition = transform.position;
        KeepStationary();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (occelationsCount == 60)
        {
            timer.StopTimer();
            ResetPosition();
            pendulumScript.RecordResults(pendulumHeightScript.getHeight(), timer.GetTime());
        }
	}
    void OnMouseDown()
    {
        if (stopped)
        {
            AllowMotion();
            ballRB.AddForce(100000, 0, 0);
            stopped = false;
            timer.StartTimer();
            occelationsCount = 0;
        }
    }
    void OnTriggerEnter()
    {
        occelationsCount++;
        occelationsText.text = "Occelations : "+occelationsCount / 2;
    }
    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        ballRB.velocity = new Vector3(0,0,0);
        stopped = true;
        KeepStationary();
        occelationsCount = 0;
        timer.StopTimer();
    }
    public Rigidbody GetRigidBody()
    {
        return ballRB;
    }
    public bool IsStopped()
    {
        return stopped;
    }
    private void KeepStationary()
    {
        ballRB.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void AllowMotion()
    {
        ballRB.constraints = RigidbodyConstraints.None;
    }
}
