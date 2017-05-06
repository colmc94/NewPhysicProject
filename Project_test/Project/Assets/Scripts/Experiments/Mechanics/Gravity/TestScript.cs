﻿using UnityEngine;
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
    public void AddResults(float x)
    {
        results.text = results.text + x.ToString("f3")+"\n";
    }
}