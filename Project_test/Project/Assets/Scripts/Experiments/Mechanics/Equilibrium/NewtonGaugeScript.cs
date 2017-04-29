using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewtonGaugeScript : MonoBehaviour
{
    private Vector3 screenPoint;//Location of the newton gauge on the screen.
    private Vector3 offset;
    public Text distance;
    void Start()
    {
        distance.text = distance.transform.name + " : " + ((transform.localPosition.x + 75) / 1.5).ToString("f2") + " cm";
    }
    void Update()
    {

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (transform.name == "Newton Gauge 1")
        {
            if (cursorPosition.x >= -74.5 && cursorPosition.x <= -42)
            {
                transform.position = cursorPosition;
                distance.text = distance.transform.name + " : " + ((transform.position.x + 75) / 1.5).ToString("f2") + " cm";
            }
        }
        else
        {
            if (cursorPosition.x >= 42 && cursorPosition.x <= 74.5)
            {
                transform.position = cursorPosition;
                distance.text = distance.transform.name + " : " + ((transform.position.x + 75) / 1.5).ToString("f2") + " cm";
            }
        }
    }
}