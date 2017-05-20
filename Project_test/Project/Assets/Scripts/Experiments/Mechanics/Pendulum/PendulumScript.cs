using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumScript : MonoBehaviour {
    public CanvasGroupScript resultsGroup,instructionsGroup;
    public ResultsScript heightResults, timeResults, gravityResults;
    public Slider timeSlider;
    private int numberOfResults;

    void Start () {
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
    public void ChangeTimeScale()
    {
        Time.timeScale = timeSlider.value;
    }
    public void RecordResults(float height, float time)
    {
        heightResults.AddResults(height);
        timeResults.AddResults(time);
        gravityResults.AddResults(CalculateGravity(height, time));
        numberOfResults++;
    }
}
