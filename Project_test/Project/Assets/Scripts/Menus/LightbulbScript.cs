using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightbulbScript : MonoBehaviour
{
    public Text title;
    public Light lightBulb;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lightBulb.enabled = false;
        title.color = new Color(0, 0, 0, 0.3f);
    }
    void OnMouseOver()
    {
        title.color = new Color(0, 0, 0, 256);
        lightBulb.enabled = true;
    }
}
