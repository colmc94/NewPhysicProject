using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnellScript : MonoBehaviour {
    public GameObject s1, f1,s2,f2,s3,f3,raybox,normal;
    public Text iText,rText,nText;
    public Material white;
    public Slider IncidentRay;
    public Toggle UI;
    public ResultsScript rs;
    private Renderer normalRend;
    private int  num =0;
    private LineRenderer lr1,lr2,lr3;
    private float i,r,n=2f,temp,w,h;
    private float[] i_results, r_results, sinI_results, sinR_results, n_results;
	// Use this for initialization
	void Start () {
        normalRend = normal.GetComponent<Renderer>();
        lr1 = s1.AddComponent<LineRenderer>();
        lr2 = s2.AddComponent<LineRenderer>();
        lr3 = s3.AddComponent<LineRenderer>();
        lr1.material = white;
        lr2.material = white;
        lr3.material = white;
        lr1.SetColors(Color.yellow,Color.yellow);
        lr2.SetColors(Color.yellow, Color.yellow);
        lr3.SetColors(Color.yellow, Color.yellow);
        lr1.SetWidth(0.5f, 0.5f);
        lr2.SetWidth(0.5f, 0.5f);
        lr3.SetWidth(0.5f, 0.5f);
        i_results = new float[10];
        r_results = new float[10];
        sinI_results = new float[10];
        sinR_results = new float[10];
        n_results = new float[10];
        w = 1920;
        h = 1080;
    }
	
	// Update is called once per frame
	void Update () {
        lr1.SetPosition(0, s1.transform.position);
        lr1.SetPosition(1, f1.transform.position);
        lr2.SetPosition(0, s2.transform.position);
        lr2.SetPosition(1, f2.transform.position);
        lr3.SetPosition(0, s3.transform.position);
        lr3.SetPosition(1, f3.transform.position);
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            IncidentRay.value = IncidentRay.value - 0.1f;
        }
        if (Input.GetKey(KeyCode.KeypadPlus) )
        {
            IncidentRay.value = IncidentRay.value + 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            UI.isOn = !UI.isOn;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RecordResult();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            normalRend.enabled = !normalRend.enabled;
        }
    }
    public void ChangeI()
    {
        raybox.transform.position = new Vector3(raybox.transform.position.x, raybox.transform.position.y, -0.5f - IncidentRay.value);
        raybox.transform.Rotate(new Vector3(0,temp-IncidentRay.value,0));
        i = Mathf.Round(100*Mathf.Atan2(IncidentRay.value,23)*Mathf.Rad2Deg)/100;
        //i = Mathf.Round(i * 100) / 100;
        r = Mathf.Round(100*(Mathf.Asin((Mathf.Sin(Mathf.Deg2Rad*i)) / n)) * Mathf.Rad2Deg)/100;
        f2.transform.position = new Vector3(f2.transform.position.x, f2.transform.position.y, -0.5f + (14 * Mathf.Tan(Mathf.Deg2Rad*r)));
        f3.transform.position = new Vector3(f3.transform.position.x, f3.transform.position.y, f2.transform.position.z + IncidentRay.value);
        iText.text = "Angle i : " + Mathf.Abs(i);
        rText.text = "Angle r : " + Mathf.Abs(r);
        nText.text = "n = " + (Mathf.Sin(i * Mathf.Deg2Rad)/ Mathf.Sin(r * Mathf.Deg2Rad)).ToString("f2");
        temp = IncidentRay.value;
    }
    public void RecordResult()
    {
        i_results[num] = Mathf.Abs(i);
        r_results[num] = Mathf.Abs(r);
        sinI_results[num] = Mathf.Sin(Mathf.Deg2Rad * Mathf.Abs(i));
        sinR_results[num] = Mathf.Sin(Mathf.Deg2Rad * Mathf.Abs(r));
        n_results[num] = Mathf.Sin(Mathf.Deg2Rad * Mathf.Abs(i)) / Mathf.Sin(Mathf.Deg2Rad * Mathf.Abs(r));
        num++;
        Debug.Log("Result " + num + " recorded");
    }
    public void OnGUI()
    {
        float ratioX = Screen.width / w;
        float ratioY = Screen.height / h;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratioX, ratioY, 1));
        if (UI.isOn == true)
        {
            rs.FiveColumns("Angle I", "Angle R", "sin I", "sin R", "sin I / sin R", i_results,r_results, sinI_results, sinR_results, n_results, num);
        }
    }
}
