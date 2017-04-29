using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeightScript : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    public Text distance;
    // Use this for initialization
    void Start () {
        distance.text = distance.transform.name + " : " + ((transform.position.x + 75) / 1.5).ToString("f2") + " cm";
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.x >= -74.5 && cursorPosition.x <= 74.5)
        {
            transform.position = cursorPosition;
            distance.text = distance.transform.name + " : " + ((transform.position.x+75)/1.5).ToString("f2") + " cm";
        }
    }
}
