using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {
    public Text timeText;
    private bool isCounting;
    private float elapsedTime;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void FixedUpdate () {
        if (isCounting)
        {
            elapsedTime = elapsedTime + Time.fixedDeltaTime;
        }
        timeText.text = elapsedTime.ToString("f3");
    }
    public float GetTime()
    {
        return elapsedTime;
    }
    public void StartTimer()
    {
        isCounting = true;
    }
    public void StopTimer()
    {
        isCounting = false;
    }
    public void ResetTimer()
    {
        elapsedTime = 0;
    }
}
