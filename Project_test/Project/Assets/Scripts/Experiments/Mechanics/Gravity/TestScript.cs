using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultsScript : MonoBehaviour {
    private Text results;
	// Use this for initialization
	void Start () {
        results = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AddResults(float x,float y)
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
    public void AddResults(float x)
    {
        results.text = results.text + x.ToString("f3")+"\n";
    }
}
