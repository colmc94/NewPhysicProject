using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//This script takes in float value and puts into one of the results column.
public class ResultsScript : MonoBehaviour {
    private Text results;
	// Use this for initialization
	void Start () {
        results = GetComponent<Text>();//Get the text object where this script is attached
	}
	// Update is called once per frame
	void Update () {
	}
    public void AddResults(float x,float y)//Allows the specification for number of decimal points
    {
        if (y == 0)
        {
            results.text = results.text + x.ToString("f0") + "\n";
        }
        else if (y == 1)
        {
            results.text = results.text + x.ToString("f1") + "\n";
        }
        else if (y == 2)
        {
            results.text = results.text + x.ToString("f2") + "\n";
        }
    }
    public void AddResults(float x)//Default is three decimal places
    {
        results.text = results.text + x.ToString("f3")+"\n";
    }
}
