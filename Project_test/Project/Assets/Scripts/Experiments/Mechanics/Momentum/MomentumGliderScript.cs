using UnityEngine;
using System.Collections;

public class MomentumGliderScript : MonoBehaviour
{
    public MomentumScript momentumScript;
    public TimerScript time1Script, time2Script;
    private Vector3 startPosition;
    private Rigidbody gliderRB;
    private bool stopped, moving;
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
    }
    public float getMass()
    {
        return mass;
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
    void OnCollisionEnter(Collision collisionInfo)
    {
        stopped = true;
        moving = false;
        momentumScript.CalculateMomentum();
    }
    void ResetPosition()
    {
        f = Random.Range(2, 12);
        transform.position = startPosition;
        stopped = false;
        time1Script.ResetTimer();
        time2Script.ResetTimer();
    }

}