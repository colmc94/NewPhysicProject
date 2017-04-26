using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class testscipt : MonoBehaviour {
    private Image[] img;
    private Text txt;
    private int count;
	// Use this for initialization
	void Start () {
        img = GetComponentsInChildren<Image>();//Gets all images associtated with the button. 1st in array is the image background of button. 2nd is image of experiment.
        txt = GetComponentInChildren<Text>();
        Debug.Log(txt.transform.name);
	}
	// Update is called once per frame
	void Update () {
	
	}
    public void LoadExperiment()
    {
        SceneManager.LoadScene(txt.transform.name);//Loads Experiment
    }
    public void ShowImage()
    {
        img[1].enabled = true;//Toggles the image of the experiment.
    }
    public void HideImage()
    {
        img[1].enabled = false;//Toggles the image of the experiment.
    }
}
