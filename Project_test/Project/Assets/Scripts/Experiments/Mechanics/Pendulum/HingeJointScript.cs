using UnityEngine;
using System.Collections;

public class HingeJointScript : MonoBehaviour {
    public BallPedulumScript ball;
    private HingeJoint pendulumJoint;
	// Use this for initialization
	void Start () {
        pendulumJoint = GetComponent<HingeJoint>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AddJoint()
    {
        pendulumJoint = gameObject.AddComponent<HingeJoint>();
        pendulumJoint.connectedBody = ball.GetRigidBody();
        pendulumJoint.anchor = new Vector3(0, 0, 0);
        pendulumJoint.axis = new Vector3(0, 0, 1);
        ball.GetRigidBody().useGravity = true;
        ball.ResetPosition();
    }
    public void DestroyJoint()
    {
        Destroy(pendulumJoint);
        ball.GetRigidBody().useGravity = false;
        ball.ResetPosition();
    }
    public void MoveJoint(float height)
    {
        transform.position = new Vector3(transform.position.x,height-9, transform.position.z);
    }
}
