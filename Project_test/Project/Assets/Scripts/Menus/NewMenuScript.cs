using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewMenuScript : MonoBehaviour {
    public Text title;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        title.color = new Color(0, 0, 0, 0.3f);
    }
    void OnMouseOver()
    {
        title.color = new Color(0, 0, 0, 256);
    }
}
