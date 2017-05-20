using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScaleScript : MonoBehaviour {
    public Text messageText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow)&&Time.timeScale <= 2.9)
        {
            Time.timeScale = Time.timeScale + 0.1f;
            messageText.text = "Time Scale : " + Time.timeScale.ToString("f1");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)&&Time.timeScale>=0.5)
        {
            Time.timeScale = Time.timeScale - 0.1f;
            messageText.text = "Time Scale : " + Time.timeScale.ToString("f1");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            messageText.text = "Time Scale : 1.0";
        }
    }
}
