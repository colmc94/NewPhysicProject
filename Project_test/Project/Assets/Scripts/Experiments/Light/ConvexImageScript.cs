using UnityEngine;
using System.Collections;

public class ConvexImageScript : MonoBehaviour
{
    public ConvexScript convexScript;
    public Material imageMaterial;
    public LensScript lens;
    public ConvexScreenScript screen;
    private float correctVPosition, u, v;
    // Use this for initialization
    void Start()
    {
        imageMaterial.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        correctVPosition = (lens.GetU() * 20) / (lens.GetU() - 20);
        imageMaterial.color = new Color(imageMaterial.color.r, imageMaterial.color.g, imageMaterial.color.b, (255 - Mathf.Abs(screen.GetV() - correctVPosition) * 30) / 255);
    }
    void OnMouseDown()
    {
        Debug.Log("Down");
        convexScript.AddResults();
    }
}
