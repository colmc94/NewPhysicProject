using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConvexScreenScript : MonoBehaviour
{
    public LensScript lens;
    public Text distVText;
    private Vector3 screenPoint;//Location of the newton gauge on the screen.
    private Vector3 offset;
    private float distV;

    void Start()
    {
        //initialPosition = transform.position;
    }
    void Update()
    {
        distV = Vector3.Distance(transform.position, lens.GetPosition());
        distVText.text = "V = " + distV.ToString("f2") + " cm";
    }
    public float GetV()
    {
        return distV;
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
        if (cursorPosition.x >= 52 && cursorPosition.x <= 90)
        {
            transform.position = cursorPosition;
        }
    }
}
