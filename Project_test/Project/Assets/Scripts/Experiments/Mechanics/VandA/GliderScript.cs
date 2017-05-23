//Script for the glider of the velocity and acceleration experiment
using UnityEngine;
using System.Collections;
//Script for the glider of the velocity and acceleration experiment
public class GliderScript : MonoBehaviour
{
    public VandAScript vandaScript;
    public TimerScript time1Script, time2Script;
    private Vector3 startPosition;
    private Rigidbody gliderRB;
    private bool stopped,moving;
    private float acceleration;
    // Use this for initialization
    void Start()
    {
        acceleration = Random.Range(2, 12);
        startPosition = transform.position;
        gliderRB = GetComponent<Rigidbody>();
    }
    // Fixed Update is called repeatedly at a fixed rate
    void FixedUpdate()
    {
        if (moving)
        {
            gliderRB.AddForce(acceleration, 0, 0, ForceMode.Acceleration);//Apply an acceleration to the glider
        }
    }
    void OnMouseDown()//Called whe nglider object is clicked on
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
    void OnCollisionEnter(Collision collisionInfo)//If glider reaches end of track stop and record all current results
    {
        stopped = true;
        moving = false;
        vandaScript.AddResults();
    }
    void ResetPosition()//Return to start position and reset timers
    {
        acceleration = Random.Range(2, 12);
        transform.position = startPosition;
        stopped = false;
        time1Script.ResetTimer();
        time2Script.ResetTimer();
    }
}