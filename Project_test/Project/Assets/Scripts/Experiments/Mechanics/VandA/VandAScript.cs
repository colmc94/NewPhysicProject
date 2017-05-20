using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VandAScript : MonoBehaviour{
    public ResultsScript time1Results, time2Results, vResults, uResults, aResults;
    public TimerScript timeScript1, timeScript2;
    public GameObject glider,lightGate1,lightGate2;
    public CanvasGroupScript resultsGroup, instructionsGroup;
    public Text resultsText;
    private Vector3 startPosition;
    private int numberOfResults;
    private float lengthOfVehicle,initalVelocity,finalVelocity,acceleration,s;
    // Use this for initialization
    void Start () {
        instructionsGroup.OnCanvasGroup();
        lengthOfVehicle = (glider.transform.localScale.x/100);
        s = lightGate2.transform.position.x - lightGate1.transform.position.x;
    }
	// Update is called once per frame
	void Update () {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
        }
    }
    public void CalculateAcceleration()
    {
        initalVelocity = lengthOfVehicle / timeScript1.GetTime();
        finalVelocity = lengthOfVehicle / timeScript2.GetTime();
        acceleration = ((finalVelocity * finalVelocity)- (initalVelocity * initalVelocity)) / (0.02f * s);
        time1Results.AddResults(timeScript1.GetTime());
        time2Results.AddResults(timeScript2.GetTime());
        uResults.AddResults(initalVelocity);
        vResults.AddResults(finalVelocity);
        aResults.AddResults(acceleration);
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
