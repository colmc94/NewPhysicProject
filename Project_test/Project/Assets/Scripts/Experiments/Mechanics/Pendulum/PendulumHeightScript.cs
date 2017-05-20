using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PendulumHeightScript : MonoBehaviour
{
    public PendulumBallScript pendulumBall;
    public Text heightText;
    public HingeJointScript pendulumJoint;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start()
    {
        heightText.text = "Height : " + ((transform.position.y - 19) / 100).ToString("f2") + " m";
    }

    void Update()
    {

    }
    public float getHeight()
    {
        return (transform.position.y - 19)/100;
    }
    void OnMouseDown()
    {
        pendulumJoint.DestroyJoint();
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
        pendulumBall.ResetPosition();
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.y >= 39 && cursorPosition.y <= 99)
        {
            transform.position = cursorPosition;
        }
        if (cursorPosition.y < 39)
        {
            transform.position = new Vector3(cursorPosition.x, 39, cursorPosition.z);
        }
        if (cursorPosition.y > 99)
        {
            transform.position = new Vector3(cursorPosition.x, 99, cursorPosition.z);
        }
        heightText.text = "Height : " + ((transform.position.y - 19) / 100).ToString("f2") + " m";
    }
    void OnMouseUp()
    {
        pendulumJoint.AddJoint();
    }
}
