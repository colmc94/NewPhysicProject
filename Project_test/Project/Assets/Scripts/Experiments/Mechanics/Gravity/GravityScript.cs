using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GravityScript : MonoBehaviour {
    public HeightScript heightScript;
    public TimerScript timerScript;
    public ResultsScript heightResults,timeResults,gravityResults;
    public CanvasGroupScript resultsGroup,instructionsGroup;
    public Text resultsText;
    private int numberOfResults;
    private float gravity;
    private bool results, instructions;
    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        instructionsGroup.OnCanvasGroup();
    }
	// Update is called once per frame
	void Update () {
        if(numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
            resultsText.text = "10 Results Recorded";
        }
    }
    public void CalculateGravity()
    {
        gravity = ((2 * heightScript.getHeight()) / 100) / (timerScript.GetTime()* timerScript.GetTime());
        heightResults.AddResults(heightScript.getHeight()/100,0);
        timeResults.AddResults(timerScript.GetTime());
        gravityResults.AddResults(gravity);
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
