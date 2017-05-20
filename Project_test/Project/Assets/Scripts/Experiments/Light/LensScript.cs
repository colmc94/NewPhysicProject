using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LensScript : MonoBehaviour
{
    private Vector3 screenPoint;//Location of the newton gauge on the screen.
    private Vector3 offset;
    private float distU;
    public Text distUText;
    void Start()
    {
        Debug.Log("Start");
        distU = transform.position.x+25 ;
    }
    void Update()
    {

    }
    public float GetU()
    {
        return distU;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
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
        if (cursorPosition.x >= 2 && cursorPosition.x <= 50)
        {
            transform.position = cursorPosition;
        }
        if (cursorPosition.x <= 2)
        {
            transform.position = new Vector3(2, cursorPosition.y, cursorPosition.z);
        }
        if (cursorPosition.x >= 50)
        {
            transform.position = new Vector3(50, cursorPosition.y, cursorPosition.z);
        }
        distU = transform.position.x + 25;
        distUText.text = "U = " + distU.ToString("f2") + " cm";
    }
}