using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SnellScript : MonoBehaviour {
    public GameObject s1, f1,s2,f2,s3,f3,raybox;
    public Material white;
    public Slider IncidentRay;
    private LineRenderer lr1,lr2,lr3;
    public class LightBeam
    {
        public LineRenderer lr;

    }
	// Use this for initialization
	void Start () {
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
    }
	
	// Update is called once per frame
	void Update () {
        lr1.SetPosition(0, s1.transform.position);
        lr1.SetPosition(1, f1.transform.position);
        lr2.SetPosition(0, s2.transform.position);
        lr2.SetPosition(1, f2.transform.position);
        lr3.SetPosition(0, s3.transform.position);
        lr3.SetPosition(1, f3.transform.position);
    }
    public void ChangeI()
    {
        raybox.transform.position = new Vector3(raybox.transform.position.x, raybox.transform.position.y, -16 + IncidentRay.value);
        //s1.transform.position = new Vector3(s1.transform.position.x, s1.transform.position.y, -11 + IncidentRay.value);
    }
}
