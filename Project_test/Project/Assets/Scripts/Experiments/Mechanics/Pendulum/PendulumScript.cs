using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumScript : MonoBehaviour {
    public CanvasGroupScript resultsGroup,instructionsGroup;
    public ResultsScript heightResults, timeResults, gravityResults;
    public Text resultsText;
    private int numberOfResults;

    void Start () {
        Time.timeScale = 1;
        instructionsGroup.OnCanvasGroup();
    }
	void Update () {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
        }
    }
    private float CalculateGravity(float height,float time)
    {
        return ((4 * Mathf.PI * Mathf.PI) * height) / ((time / 30)* (time / 30));
    }
    public void RecordResults(float height, float time)
    {
        heightResults.AddResults(height);
        timeResults.AddResults(time);
        gravityResults.AddResults(CalculateGravity(height, time));
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
