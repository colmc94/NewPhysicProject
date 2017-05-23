using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoylesLawScript : MonoBehaviour {
    public ValveScript valve;
    public GameObject dial, liquid;
    public Text pressureText, volumeText;
    public ResultsScript volumeResults, pressureResults;
    public CanvasGroupScript resultsGroup,instructionsGroup;
    public Text resultsText;
    private float pressure, volume, k;
    private int numberOfResults;

	void Start () {
        Time.timeScale = 1;
        k = 1500;
        pressure = 225;
        instructionsGroup.OnCanvasGroup();
    }
	// Update is called once per frame
	void Update () {
        if (numberOfResults == 10)
        {
            resultsGroup.OnCanvasGroup();
        }
        if (valve.IsOpen()&&volume<71)
        {
            pressure = pressure - 0.2f;
        }
        UpdateGraphics();
    }
    private void UpdateGraphics()//Update boyles law apparatus to show correct readings
    {
        volume = k / pressure;
        liquid.transform.localScale = new Vector3(1,.995f-(.125f*(volume/10)), 1);//Show correct volume of gas. Scale of y changes depending on volume
        dial.transform.rotation = Quaternion.Euler(93 + (29.5f*(pressure/25)), 90, 0);//Rotate dial to show correctvalue on pressure gauge. Rotate dial about the y axis.
        pressureText.text = "Pressure : "+pressure.ToString("f2")+ " Pa";
        volumeText.text = "Volume : "+volume.ToString("f2") + " cm^3";
    }
    public void RecordResults()
    {
        volumeResults.AddResults(volume);
        pressureResults.AddResults(pressure);
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
