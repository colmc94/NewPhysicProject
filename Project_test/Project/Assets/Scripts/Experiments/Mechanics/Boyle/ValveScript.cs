using UnityEngine;
using System.Collections;

public class ValveScript : MonoBehaviour {
    public BoylesLawScript boyleLaw;
    private bool open;
	// Use this for initialization
	void Start () {
        open = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public bool IsOpen()
    {
        return open;
    }
    void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        open = !open;
        if (!open)
        {
            boyleLaw.RecordResults();
        }
    }
}
