using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Equilibirum : MonoBehaviour {
    public GameObject s1,s2,s3,s4,s5,s6,f1,f2,f3,f4,f5,f6,weight1,weight2,weight3,weight4,newton1,newton2,g1,g2;
    public Material white;
    public Slider weight1Slider, weight2Slider, weight3Slider, weight4Slider,newton1Slider,newton2Slider,gs1,gs2;
    public Text weight1Text, weight2Text, weight3Text, weight4Text, newton1Text, newton2Text,g1Text,g2Text;
    private LineRenderer lr1,lr2,lr3,lr4,lr5,lr6;
    // Use this for initialization
    void Start () {
        lr1 = s1.AddComponent<LineRenderer>();
        lr2 = s2.AddComponent<LineRenderer>();
        lr3 = s3.AddComponent<LineRenderer>();
        lr4 = s4.AddComponent<LineRenderer>();
        lr5 = s5.AddComponent<LineRenderer>();
        lr6 = s6.AddComponent<LineRenderer>();
        lr1.material = white;
        lr2.material = white;
        lr3.material = white;
        lr4.material = white;
        lr5.material = white;
        lr6.material = white;
        lr1.SetWidth(0.2f, 0.2f);
        lr2.SetWidth(0.2f, 0.2f);
        lr3.SetWidth(0.2f, 0.2f);
        lr4.SetWidth(0.2f, 0.2f);
        lr5.SetWidth(0.2f, 0.2f);
        lr6.SetWidth(0.2f, 0.2f);
        MoveWeights();
        MoveNewtons();
        MoveGauge();
    }
	
	// Update is called once per frame
	void Update () {
        lr1.SetPosition(0, s1.transform.position);
        lr1.SetPosition(1, f1.transform.position);
        lr2.SetPosition(0, s2.transform.position);
        lr2.SetPosition(1, f2.transform.position);
        lr3.SetPosition(0, s3.transform.position);
        lr3.SetPosition(1, f3.transform.position);
        lr4.SetPosition(0, s4.transform.position);
        lr4.SetPosition(1, f4.transform.position);
        lr5.SetPosition(0, s5.transform.position);
        lr5.SetPosition(1, f5.transform.position);
        lr6.SetPosition(0, s6.transform.position);
        lr6.SetPosition(1, f6.transform.position);
    }
    public void MoveWeights()
    {
        weight1.transform.position = new Vector3(0,20,weight1Slider.value);
        weight2.transform.position = new Vector3(0, 20, weight2Slider.value);
        weight3.transform.position = new Vector3(0, 20, weight3Slider.value);
        weight4.transform.position = new Vector3(0, 20, weight4Slider.value);
        weight1Text.text = weight1Slider.value + " cm";
        weight2Text.text = weight2Slider.value + " cm";
        weight3Text.text = weight3Slider.value + " cm";
        weight4Text.text = weight4Slider.value + " cm";
    }
    public void MoveNewtons()
    {
        newton1.transform.localPosition = new Vector3(-0.73f, 75.5f, newton1Slider.value);
        newton2.transform.localPosition = new Vector3(1, 75.5f, newton2Slider.value*-1);
        newton1Text.text = newton1Slider.value + " N";
        newton2Text.text = newton2Slider.value + " cm";
    }
    public void MoveGauge()
    {
        g1.transform.localPosition = new Vector3(-0.1f,0.51f,gs1.value);
        g2.transform.localPosition = new Vector3(0.05f, 0.65f, gs2.value);
        g1Text.text = ((gs1.value + 3.8) / 0.8).ToString("f1") + " N";
        g2Text.text = gs2.value + " cm";
    }
}
