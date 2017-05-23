using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoyleScript : MonoBehaviour
{
    private float pressure, volume, k;
    void Start()
    {

    }
    void Update()
    {

    }
    /*public ResultsScript rs;
    public Slider pressure;
    public Toggle UI;
    public GameObject dial, therm;
    public Text volumeText, pressureText;
    private int k, count;
    private float p, v;
    private float[] pressureResult, volumeResult;
    // Use this for initialization
    void Start()
    {
        k = 1000;
        gauge();
        pressureResult = new float[10];
        volumeResult = new float[10];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadMinus) && (125 - (k / ((pressure.value * 30) - 30)))>5)
        {
            pressure.value = pressure.value - 0.01f;
        }
        if(Input.GetKey(KeyCode.KeypadPlus) && (125 - (k / ((pressure.value * 30) - 30))) < 125)
        {
            pressure.value = pressure.value + 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UI.isOn = !UI.isOn;
        }
    }
    public void gauge()
    {
        dial.transform.rotation = Quaternion.Euler(pressure.value * 45, 0, 90);
        therm.transform.localScale = new Vector3(3, 125 - (k / ((pressure.value * 30) - 30)), 1.7f);
        volumeText.text = "Volume = " + (k / ((pressure.value * 30) - 30)).ToString("f2") + " cm^3";
        pressureText.text = "Pressure = " + ((pressure.value * 30) - 30).ToString("f2") + " kPa";
    }
    public void storeResult()
    {
        p = Mathf.Round(((pressure.value * 30) - 30) * 100) / 100;
        pressureResult[count] = p;
        v = Mathf.Round(k / ((pressure.value * 30) - 30) * 100) / 100;
        volumeResult[count] = v;
        count++;
        Debug.Log("Result "+count+" stored.");
    }
    public void OnGUI()
    {
        /*float ratioX = Screen.width / w;
        float ratioY = Screen.height / h;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratioX, ratioY, 1));*/
        //float ratioX = Screen.width /1920;
        //float ratioY = Screen.height / 1080;
        //GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratioX, ratioY, 1));
        /*if (UI.isOn==true)
        {
            rs.TwoResults("Pressure(kPa)", "Volume(cm^3)", pressureResult, volumeResult, count);
        }
    }*/
}
