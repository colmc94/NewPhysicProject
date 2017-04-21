/*Script for the speaker logo for the sound section in the amin menu*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundScript : MonoBehaviour
{
    public GameObject s1, s2, s3;
    public Text title;
    private Renderer r1,r2,r3;
    // Use this for initialization
    void Start()
    {
        r1 = s1.GetComponent<Renderer>();
        r2 = s2.GetComponent<Renderer>();
        r3 = s3.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        title.color = new Color(0, 0, 0, 0.3f);
        r1.enabled = false;
        r2.enabled = false;
        r3.enabled = false;
    }
    void OnMouseOver()
    {
        title.color = new Color(0, 0, 0, 256);
        r1.enabled = true;
        r2.enabled = true;
        r3.enabled = true;
    }
}
