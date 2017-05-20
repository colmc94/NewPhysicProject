using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MirrorScript : MonoBehaviour
{
    private Vector3 screenPoint;//Location of the newton gauge on the screen.
    private Vector3 offset;
    private Vector3 initialPosition,screenPosition;
    private float distU;
    public GameObject screen,thread;
    public Text distUText;
    //public Text distance;
    void Start()
    {
        distU = Vector3.Distance(thread.transform.position, transform.position) / 2;
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
        initialPosition = transform.position;
        screenPosition = screen.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, screenPoint.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.x >= 0 && cursorPosition.x <= 95)
        {
            transform.position = cursorPosition;
            screen.transform.position = new Vector3(screenPosition.x+(cursorPosition.x-initialPosition.x),screen.transform.position.y,screen.transform.position.z);
            distU = Vector3.Distance(thread.transform.position, transform.position) / 2;
        }
        if(cursorPosition.x <= 32)
        {
            transform.position = new Vector3(32,cursorPosition.y,cursorPosition.z);
            screen.transform.position = new Vector3(screenPosition.x + (32 - initialPosition.x), screen.transform.position.y, screen.transform.position.z);
            distU = 30;
        }
        if (cursorPosition.x >= 92)
        {
            transform.position = new Vector3(92f, cursorPosition.y, cursorPosition.z);
            screen.transform.position = new Vector3(screenPosition.x + (92f - initialPosition.x), screen.transform.position.y, screen.transform.position.z);
            distU = 60;
        }
        distUText.text = "U = " + distU.ToString("f2") + " cm";
    }
}