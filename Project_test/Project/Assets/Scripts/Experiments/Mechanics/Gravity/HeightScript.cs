using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeightScript : MonoBehaviour {
    public BallScript ballScript;
    public Text heightText;
    public GameObject magnet, ball;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Start () {
        heightText.text = "Height : " + ((transform.position.y - 17)/100).ToString("f2") + " m";
    }
	
	void Update () {

	}
    public float getHeight()
    {
        return transform.position.y - 17;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.y >= 37 && cursorPosition.y <= 127)
        {
            transform.position = cursorPosition;
        }
        if (cursorPosition.y < 37)
        {
            transform.position = new Vector3(cursorPosition.x, 37, cursorPosition.z);
        }
        if (cursorPosition.y > 127)
        {
            transform.position = new Vector3(cursorPosition.x, 127, cursorPosition.z);
        }
        magnet.transform.position = new Vector3(magnet.transform.position.x, transform.position.y - 4, magnet.transform.position.z);
        if (!ballScript.isLanded()) {
            ball.transform.position = new Vector3(ball.transform.position.x, transform.position.y - 9.5f, ball.transform.position.z);
        }
        heightText.text = "Height : " + ((transform.position.y - 17) / 100).ToString("f2") + " m";
    }
}
