/*Script for rotating the gears for the mechanics section in the amin menu*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GearScript : MonoBehaviour
{
    public GameObject g1, g2, g3;
    public Text title;
    private int count;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        title.color = new Color(0, 0, 0, 0.3f);
    }
    void OnMouseOver()
    {
        title.color = new Color(0, 0, 0, 256);
        g1.transform.rotation = Quaternion.Euler(0, count / 2, 0);
        g2.transform.rotation = Quaternion.Euler(0, -count / 2, 0);
        g3.transform.rotation = Quaternion.Euler(0, count / 2, 0);
        count++;
    }
}
