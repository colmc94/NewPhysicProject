using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasGroupScript : MonoBehaviour {
    private CanvasGroup canvasGroup;
    private Image canvasGroupImage;
	void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroupImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ToggleCanvasGroup()
    {
        if (canvasGroup.alpha == 0)
        {
            canvasGroup.alpha = 1;
            canvasGroupImage.enabled=true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroupImage.enabled = false;
        }
    }
    public void OnCanvasGroup()
    {
        canvasGroup.alpha = 1;
        canvasGroupImage.enabled = true;
    }
    public void OffCanvasGroup()
    {
        canvasGroup.alpha = 0;
        canvasGroupImage.enabled = false;
    }
    public bool isOn()
    {
        return canvasGroup.alpha == 1;
    }
}
