using UnityEngine;
using System.Collections;

public class AandFGliderScript : MonoBehaviour
{
    public AandFScript aAndFScript;
    public TimerScript time1Script, time2Script;
    public NewtonScript newtonScript;
    private Vector3 startPosition;
    private Rigidbody gliderRB;
    private bool stopped, moving;
    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        gliderRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            gliderRB.AddForce(newtonScript.GetNewtons(), 0, 0, ForceMode.Acceleration);
        }

    }
    public bool IsStopped()
    {
        return stopped;
    }
    public bool IsMoving()
    {
        return moving;
    }
    void OnMouseDown()
    {
        ClickSystem();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        stopped = true;
        moving = false;
        aAndFScript.CalculateAcceleration();
    }
    void ResetPosition()
    {
        transform.position = startPosition;
        newtonScript.ResetPosition();
        stopped = false;
        time1Script.ResetTimer();
        time2Script.ResetTimer();
    }
    public void ClickSystem()
    {
        if (stopped)
        {
            ResetPosition();
        }
        else
        {
            moving = true;
        }
    }
}