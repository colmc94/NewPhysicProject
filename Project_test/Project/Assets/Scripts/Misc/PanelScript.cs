using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelScript : MonoBehaviour {
    private Image background;
	// Use this for initialization
	void Start () {
        background = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MouseEnter()
    {
        background.color = new Color(background.color.r,background.color.g,background.color.b,0.3f);
    }
    public void MouseExit()
    {
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0);
    }
}
