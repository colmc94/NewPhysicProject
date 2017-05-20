using UnityEngine;
using System.Collections;

public class HingeJointScript : MonoBehaviour {
    public GameObject cork;
    private HingeJoint pendulumJoint;
    private float corkHeight;
	// Use this for initialization
	void Start () {
        pendulumJoint = GetComponent<HingeJoint>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AddJoint()
    {
        corkHeight = cork.transform.position.y - transform.position.y;
        pendulumJoint = gameObject.AddComponent<HingeJoint>();
        pendulumJoint.anchor = new Vector3(0, corkHeight/4, 0);
        pendulumJoint.axis = new Vector3(0, 0, 1);
    }
    public void DestroyJoint()
    {
        Destroy(pendulumJoint);
    }
}
