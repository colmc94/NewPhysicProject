using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MomentumScript : MonoBehaviour
{
    public ResultsScript time1Results, time2Results, vResults, uResults, aResults;
    public TimerScript timeScript1, timeScript2;
    public GameObject glider, lightGate1, lightGate2;
    public CanvasGroupScript resultsGroup, instructionsGroup;
    public MomentumGliderScript glider1;
    public Text resultsText;
    private Vector3 startPosition;
    private int numberOfResults;
    private float lengthOfVehicle, initalVelocity, finalVelocity, momentumBefore, s;
    // Use this for initialization
    void Start()
    {
       // instructionsGroup.OnCanvasGroup();
        lengthOfVehicle = 0.067f;
        s = lightGate2.transform.position.x - lightGate1.transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
        }
    }
    public void CalculateMomentum()
    {
        initalVelocity = lengthOfVehicle / timeScript1.GetTime();
        Debug.Log("u = " + initalVelocity + " l = " + lengthOfVehicle);
        finalVelocity = lengthOfVehicle / timeScript2.GetTime();
        momentumBefore = glider1.getMass()*initalVelocity;
        time1Results.AddResults(timeScript1.GetTime());
        time2Results.AddResults(timeScript2.GetTime());
        uResults.AddResults(initalVelocity);
        vResults.AddResults(finalVelocity);
        aResults.AddResults(momentumBefore);
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
