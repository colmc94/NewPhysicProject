using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pendulum : MonoBehaviour {
    public GameObject ball,cork;
    public Slider ballPositionSlider,ballHeightSlider;
    public Material white;
    public Text TimeText;
    private Rigidbody rbBall,rbCork;
    private float distance,temp,ypos,z,speed,elapsedTime,finishTime;
    private Renderer normalRend;
    private LineRenderer lr1;
    private int count;
    private HingeJoint hinge;
    // Use this for initialization
    void Start () {
        rbBall = GetComponent<Rigidbody>();
        rbCork = cork.GetComponent<Rigidbody>();
        lr1 = cork.AddComponent<LineRenderer>();
        lr1.material = white;
        //lr1.SetColors(Color.yellow, Color.yellow);
        lr1.SetWidth(0.1f, 0.1f);
        distance = Vector3.Distance(ball.transform.position, cork.transform.position);
        hinge = cork.AddComponent<HingeJoint>();
        hinge.connectedBody = rbBall;
        Debug.Log("Distance: " + distance);
	}
	// Update is called once per frame
	void FixedUpdate () {
        if (rbBall.useGravity)
        {
            if (count >= 60)
            {
                TimeText.text = elapsedTime.ToString("f4");
            }
            else
            {
                elapsedTime = elapsedTime + Time.fixedDeltaTime;
                TimeText.text = (elapsedTime).ToString("f4");
            }
        }
        Debug.Log("Distance: " + distance + " y : "+ypos+" count = "+count/2);
        lr1.SetPosition(0, cork.transform.position);
        lr1.SetPosition(1, ball.transform.position);
    }
    void OnTriggerEnter(Collider other)
    {
        count++;
    }
    public void StartExp()
    {
        rbBall.useGravity = true;
    }
    public void ResetExp()
    {
        ballPositionSlider.value = 0;
        ball.transform.position = new Vector3(0, Mathf.Abs(ypos), 2.5f + ballPositionSlider.value);
        rbBall.useGravity = false;
        count = 0;
        elapsedTime = 0;
        rbBall.velocity = new Vector3(0, 0, 0);
    }
    public void moveBall()
    {
        temp = 2.5f + ballPositionSlider.value;
        z = temp - cork.transform.position.z;
        ypos = Mathf.Sqrt((distance * distance)-(z*z))-cork.transform.position.y;
        ball.transform.position = new Vector3(0,Mathf.Abs(ypos), 2.5f+ballPositionSlider.value);
        distance = Vector3.Distance(ball.transform.position, cork.transform.position);
    }
    public void setHeight()
    {
        Destroy(hinge);
        ballPositionSlider.value = 0;
        ball.transform.position = new Vector3(0, ballHeightSlider.value, 2.5f + ballPositionSlider.value);
        distance = Vector3.Distance(ball.transform.position, cork.transform.position);
        hinge = cork.AddComponent<HingeJoint>();
        hinge.connectedBody =rbBall;
    }
}
