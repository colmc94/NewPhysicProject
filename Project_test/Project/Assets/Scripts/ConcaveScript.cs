using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConcaveScript : MonoBehaviour {
    public Material image;
    public Text test;
    private float a,r,g,b;
    private Color orginal;
	// Use this for initialization
	void Start () {
        //image.color = new Color(255, 255, 255, 255);
        orginal = image.color;
        a = image.color.a;
        r = image.color.r;
        g = image.color.g;
        b = image.color.b;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, (image.color.a)+0.001f);
            Debug.Log("Pressing -");
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, (image.color.a) - 0.001f);
            Debug.Log("Pressig +");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            image.color = orginal;
            Debug.Log("Reset");
        }
        test.text = "a = " + image.color.a+ " r = " + image.color.r+ " g = " + image.color.g+ " b = " + image.color.b;
    }
}
