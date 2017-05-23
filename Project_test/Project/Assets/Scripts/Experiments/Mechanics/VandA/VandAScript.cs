using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//Main script for velocity and acceleration experiment. Using values for time from the Timer script it Calcuulates initial velocity(u),final velocity(v) and acceleration(a) 
public class VandAScript : MonoBehaviour{
    public ResultsScript time1Results, time2Results, vResults, uResults, aResults;//Results columns
    public TimerScript timeScript1, timeScript2;//Times need for calculating initial and final velocity
    public GameObject glider,lightGate1,lightGate2;//Objects needed for detemining values for l(length of glider) and s (distance betweeen light gates)
    public CanvasGroupScript resultsGroup, instructionsGroup;//Panels that display results and instructions
    public Text resultsText;//Text for message box
    private int numberOfResults;
    private float lengthOfVehicle,s;//Variables for l,u,v,a and s
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        instructionsGroup.OnCanvasGroup();//Displays instruction upon setting up experiment
        lengthOfVehicle = (glider.transform.localScale.x/100);//Gets length of the glider
        s = lightGate2.transform.position.x - lightGate1.transform.position.x;//Gets distance between lightgates.
    }
	// Update is called once per frame
	void Update () {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();//Results display when max count is reached
        }
    }
    private float CalculateU()//Get initial velocity of glider
    {
        return lengthOfVehicle / timeScript1.GetTime();
    }
    private float CalculateV()//Get final velocity of glider
    {
        return lengthOfVehicle / timeScript2.GetTime();
    }
    private float CalculateAccleration(float u,float v)//Returns the acceleartion of the glider in the experiment, given inital and final vleocity parameters
    {
        return ((v * v) - (u * u)) / (0.02f*s);//Formula a = (v^2-u^2)/2s
    }
    public void AddResults()//Add all results from this experiment into the results table
    {
        time1Results.AddResults(timeScript1.GetTime());
        time2Results.AddResults(timeScript2.GetTime());
        uResults.AddResults(CalculateU());
        vResults.AddResults(CalculateV());
        aResults.AddResults(CalculateAccleration(CalculateU(), CalculateV()));
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";//Display result count in message box
    }
}
