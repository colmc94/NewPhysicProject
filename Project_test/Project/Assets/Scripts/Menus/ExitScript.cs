using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitScript : MonoBehaviour
{
    public Text title;
    public Material material;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        material.color = new Color(0.5f,0.5f,0.5f,1);
        title.color = new Color(0, 0, 0, 0.3f);
    }
    void OnMouseOver()
    {
        title.color = new Color(0.5f, 0.5f, 0.5f, 1);
        material.color = new Color(1, 0, 0, 1);
    }
    void OnMouseDown()
    {
        Application.Quit();
    }
}
