using UnityEngine;
using System.Collections;

public class MomentumGlider2Script : MonoBehaviour {
    public MomentumGliderScript momentumGlider;
    public MomentumScript momentumScript;
    private Rigidbody gliderRB;
    private Vector3 startPosition;
    private float mass;
    private bool collision;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        gliderRB = GetComponent<Rigidbody>();
        mass = gliderRB.mass;
    }	
	// Update is called once per frame
	void Update () {
	
	}
    public float getMass()
    {
        return mass;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collision)
        {
            momentumScript.CalculateMomentum();
            momentumGlider.Stop();
            collision = false;
        }
        else
        {
            collision = true;
        }
    }
    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
