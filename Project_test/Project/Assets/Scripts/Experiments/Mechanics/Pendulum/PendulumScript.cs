using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumScript : MonoBehaviour {
    public CanvasGroupScript resultsGroup,instructionsGroup;
    private int numberOfResults;
    /*public GameObject ball,cork;
    public Slider ballPositionSlider,ballHeightSlider;
    public Material white;
    public Text TimeText,heightText;
    public OldResultScript resultScript;
    public Toggle UI;
    private float[] time1Results, time2Results, heightResults, gResults;
    private Rigidbody rbBall;
    private float distance,temp,ypos,z,speed,elapsedTime,finishTime,w,h;
    private LineRenderer lr1;
    private int count,i;
    private HingeJoint hinge;*/
    // Use this for initialization
    void Start () {
        instructionsGroup.OnCanvasGroup();
    }
	// Update is called once per frame
	void Update () {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
        }
        /*if (rbBall.useGravity)
        {
            if (count == 60)
            {
                TimeText.text = elapsedTime.ToString("f2");
                storeResults();
            }
            else
            {
                elapsedTime = elapsedTime + Time.fixedDeltaTime;
                TimeText.text = (elapsedTime).ToString("f2");
            }
        }
        distance = Vector3.Distance(ball.transform.position, cork.transform.position);
        lr1.SetPosition(0, cork.transform.position);
        lr1.SetPosition(1, ball.transform.position);*/
    }
    /*void OnTriggerExit(Collider other)
    {
        count++;
        Debug.Log("Count = " + count / 2 + " oscillations");
    }
    private void storeResults()
    {
        time1Results[i] = elapsedTime;
        time2Results[i] = elapsedTime / 30;
        heightResults[i] = distance/100;
        float g = ((4 * (Mathf.PI* Mathf.PI)) * (distance/100)) / ((elapsedTime / 30)* (elapsedTime / 30));
        gResults[i] = g;
        i++;
        Debug.Log("Result " + i + " stored. G= "+g+ "m/s^2");
        ResetExp();
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
        lr1.SetPosition(0, cork.transform.position);
        lr1.SetPosition(1, ball.transform.position);
        distance = Vector3.Distance(ball.transform.position, cork.transform.position);
    }
    public void setHeight()
    {
        Destroy(hinge);
        ballPositionSlider.value = 0;
        ball.transform.position = new Vector3(0, ballHeightSlider.value, 2.5f + ballPositionSlider.value);
        lr1.SetPosition(0, cork.transform.position);
        lr1.SetPosition(1, ball.transform.position);
        distance = Vector3.Distance(ball.transform.position, cork.transform.position);
        hinge = cork.AddComponent<HingeJoint>();
        hinge.connectedBody =rbBall;
        heightText.text = distance.ToString("f2") + " m";
    }
    public void OnGUI()
    {
        float ratioX = Screen.width / w;
        float ratioY = Screen.height / h;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratioX, ratioY, 1));
        if (UI.isOn == true)
        {
            resultScript.ThreeResults("Height(m)", "Time(s)", "Gravity(m/s^2)", heightResults, time1Results, gResults, i);
        }
    }*/
}
