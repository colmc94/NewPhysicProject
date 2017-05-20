using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RayboxScript : MonoBehaviour
{
    private Vector3 screenPoint;//Location of the newton gauge on the screen.
    private Vector3 offset;
    private Vector3 initialPosition,r2Position;
    public GameObject r1,r2;
    public Text angleIText,angleRText;
    //public Text distance;
    void Start()
    {
        angleIText.text = "Angle i = " + CalculateIndicidenceAngle().ToString("f2") + " degress";
        angleRText.text = "Angle r = " + CalculateRefractionAngle(CalculateIndicidenceAngle()).ToString("f2") + " degress";
    }
    void Update()
    {

    }
    public float getI()
    {
        return CalculateIndicidenceAngle();
    }
    public float getR()
    {
        return CalculateRefractionAngle(CalculateIndicidenceAngle());
    }
    void OnMouseDown()
    {
        Debug.Log("Down");
        initialPosition = transform.position;
        r2Position = r2.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(screenPoint.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        if (cursorPosition.z >= -30 && cursorPosition.z <=30)
        {
            transform.position = cursorPosition;
            r2.transform.position = new Vector3(r2.transform.position.x, r2.transform.position.y,-cursorPosition.z);
        }
        if (cursorPosition.z <= -30)
        {
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, -30);
        }
        if (cursorPosition.x >= 30)
        {
            transform.position = new Vector3(cursorPosition.x, cursorPosition.y, 30);
        }
        r2.transform.position = new Vector3(r2.transform.position.x, r2.transform.position.y, -transform.position.z);
        transform.eulerAngles = new Vector3(0, 90 + transform.position.z, 0);
        Debug.Log(CalculateIndicidenceAngle());
        angleIText.text = "Angle i = " + CalculateIndicidenceAngle().ToString("f2") + " degress";
        angleRText.text = "Angle r = " + CalculateRefractionAngle(CalculateIndicidenceAngle()).ToString("f2") + " degress";
        if (transform.position.z <= 0)
        {
            r1.transform.position = new Vector3(r1.transform.position.x, r1.transform.position.y, 15 * Mathf.Tan(Mathf.Deg2Rad * CalculateRefractionAngle(CalculateIndicidenceAngle())));
        }
        else
        {
            r1.transform.position = new Vector3(r1.transform.position.x, r1.transform.position.y, -15 * Mathf.Tan(Mathf.Deg2Rad * CalculateRefractionAngle(CalculateIndicidenceAngle())));
        }
        // distUText.text = "U = " + distU.ToString("f2") + " cm";
    }
    private float CalculateIndicidenceAngle()
    {
        return Mathf.Abs((Mathf.Atan2(27.5f, Mathf.Abs(transform.position.z)) * Mathf.Rad2Deg)-90);
        //return 0;
    }
    private float CalculateRefractionAngle(float i)
    {
        return ((Mathf.Asin(((Mathf.Sin(Mathf.Deg2Rad * i)) / 2f)) *Mathf.Rad2Deg));
    }
}