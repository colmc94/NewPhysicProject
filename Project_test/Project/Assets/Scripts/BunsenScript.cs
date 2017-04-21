using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class BunsenScript : MonoBehaviour
{
    public GameObject g1;
    public Text title;
    private Renderer r1;
    // Use this for initialization
    void Start()
    {
        r1 = g1.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r1.enabled = false;
        title.color = new Color(0, 0, 0, 0.3f);
    }
    void OnMouseOver()
    {
        title.color = new Color(0, 0, 0, 256);
        r1.enabled = true;
    }
    void OnMouseDown()
    {
        SceneManager.LoadScene("Gravity");
    }
}
