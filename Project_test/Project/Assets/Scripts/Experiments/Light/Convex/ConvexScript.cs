﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConvexScript : MonoBehaviour
{
    public CanvasGroupScript resultsGroup, instructionsGroup;
    public LensScript lens;
    public ConvexScreenScript screen;
    public ResultsScript uResults, vResults, uInverseResults, vInverseResults, fResults;
    public Text resultsText;
    private float u, v, f;
    private int numberOfResults;
    // Use this for initialization
    void Start()
    {
        instructionsGroup.OnCanvasGroup();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfResults >= 10)
        {
            resultsGroup.OnCanvasGroup();
            resultsText.text = "10 Results Recorded";
        }
    }
    private float CalculateF(float x, float y)
    {
        return (x * y) / (x + y);
    }
    public void AddResults()
    {
        u = lens.GetU();
        v = screen.GetV();
        f = CalculateF(u, v);
        uResults.AddResults(u,2);
        vResults.AddResults(v,2);
        uInverseResults.AddResults(1 / u);
        vInverseResults.AddResults(1 / v);
        fResults.AddResults(f);
        numberOfResults++;
        resultsText.text = "Result " + numberOfResults + " Recorded";
    }
}
