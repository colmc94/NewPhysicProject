using UnityEngine;
using System.Collections;

public class MomentumGliderScript : MonoBehaviour
{
    //public MomentumScript momentumScript;
    public MomentumGlider2Script momentumGlider;
    public TimerScript time1Script, time2Script;
    private Vector3 startPosition;
    private Rigidbody gliderRB;
    private bool stopped, moving,collision;
    private float f,mass;
    // Use this for initialization
    void Start()
    {
        f = Random.Range(2, 12);
        startPosition = transform.position;
        gliderRB = GetComponent<Rigidbody>();
        mass = gliderRB.mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            gliderRB.AddForce(f, 0, 0, ForceMode.Acceleration);
        }
        else if (stopped)
        {
            gliderRB.velocity = new Vector3(0, 0, 0);
        }
    }
    public float getMass()
    {
        return mass;
    }
    public void Stop()
    {
        stopped = true;
        moving = false;
    }
    void OnMouseDown()
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
    void ResetPosition()
    {
        f = Random.Range(2, 12);
        transform.position = startPosition;
        stopped = false;
        time1Script.ResetTimer();
        time2Script.ResetTimer();
        momentumGlider.ResetPosition();
    }

}