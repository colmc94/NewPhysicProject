using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenScript : MonoBehaviour {
    public MirrorScript mirror;
    public Text distVText;
    private Vector3 screenPoint;//Location of the newton gauge on the screen.
    private Vector3 offset;
    private float distV;

    void Start()
    {
        distV = Vector3.Distance(transform.position, mirror.GetPosition());
    }
    void Update()
    {

    }
    public float GetV()
    {
        return distV;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.y, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.y, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.z >= -35 && cursorPosition.z <= 3)
        {
            transform.position = cursorPosition;
        }
        distV = Vector3.Distance(transform.position, mirror.GetPosition());
        distVText.text = "V = " + distV.ToString("f2") + " cm";
    }
}
