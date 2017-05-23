using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MomentumScript : MonoBehaviour
{
    public ResultsScript time1Results, time2Results, vResults, uResults, m1Results,m2Results;
    public TimerScript timeScript1, timeScript2;
    public GameObject glider, lightGate1, lightGate2;
    public CanvasGroupScript resultsGroup, instructionsGroup;
    public MomentumGliderScript glider1;
    public Text resultsText;
    private Vector3 startPosition;
    private int numberOfResults;
    private float lengthOfVehicle, initalVelocity, finalVelocity;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        instructionsGroup.OnCanvasGroup();
        lengthOfVehicle = 0.067f;
    }
    // Update is called once per frame
    void Update()
    {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
        }
    }
    public float GetU()
    {
        return lengthOfVehicle / timeScript1.GetTime();
    }
    public void CalculateMomentum()
    {
        initalVelocity = lengthOfVehicle / timeScript1.GetTime();
        finalVelocity = lengthOfVehicle / timeScript2.GetTime();
        time1Results.AddResults(timeScript1.GetTime());
        time2Results.AddResults(timeScript2.GetTime());
        uResults.AddResults(initalVelocity);
        vResults.AddResults(finalVelocity);
        m1Results.AddResults(initalVelocity);
        m2Results.AddResults(1.153f*finalVelocity);
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
