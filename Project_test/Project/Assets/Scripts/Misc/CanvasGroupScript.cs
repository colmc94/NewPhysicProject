using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasGroupScript : MonoBehaviour {
    public KeyCode key;
    public CanvasGroup otherCanvasGroup1, otherCanvasGroup2;
    private CanvasGroup canvasGroup;
    void Start () {
        canvasGroup = GetComponent<CanvasGroup>();
	}
	void Update () {
        if (Input.GetKeyDown(key))
        {
            ToggleCanvasGroup();
            otherCanvasGroup1.alpha = 0;
            otherCanvasGroup1.blocksRaycasts = false;
            otherCanvasGroup2.alpha = 0;
            otherCanvasGroup2.blocksRaycasts = false;
        }
	}
    private void ToggleCanvasGroup()
    {
        if (canvasGroup.alpha == 0)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts=true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }
    }
    public void OnCanvasGroup()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts= true;
    }
    public void OffCanvasGroup()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
