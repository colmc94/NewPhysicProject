using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConvexScript : MonoBehaviour
{
    public OldResultScript rs;
    public Material image;
    public Text test, test1, uSliderText, vSliderText;
    public Slider uSlider, vSlider;
    public GameObject lens,Beam, screen, screenDispaly;
    public Toggle UI;
    private float a, r, g, b, u, v, f, correctValue, difference;
    private Vector3 screenDisplayPos;
    private float[] uResults, vResults;
    private int count;
    // Use this for initialization
    void Start()
    {
        image.color = new Color(1, 1, 1, 0);
        f = 20;
        screenDisplayPos = Camera.main.ScreenToWorldPoint(new Vector3(100, 100, 200));
        screenDispaly.transform.position = screenDisplayPos;
        uResults = new float[10];
        vResults = new float[10];
        vSliderText.text = (55 - (vSlider.value * 2)).ToString("f1") + " cm";
        uSliderText.text = (25 + uSlider.value).ToString("f1") + " cm";
    }

    // Update is called once per frame
    void Update()
    {
        if (vSlider.interactable == true)
        {
            v = 40 + (vSlider.value * 2);
            difference = Mathf.Abs(v - correctValue);
            image.color = new Color(image.color.r, image.color.g, image.color.b, (255 - difference * 30) / 255);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                recordResult();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            setU();
        }
        if (Input.GetKey(KeyCode.LeftArrow) && uSlider.interactable)
        {
            uSlider.value = uSlider.value - 0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && uSlider.interactable)
        {
            uSlider.value = uSlider.value + 0.1f;
        }
        if (Input.GetKey(KeyCode.UpArrow) && vSlider.interactable)
        {
            vSlider.value = vSlider.value - 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && vSlider.interactable)
        {
            vSlider.value = vSlider.value + 0.1f;
        }
        test1.text = "u = " + u.ToString("f1") + " v = " + v + " real v = " + correctValue.ToString("f2") + " a = " + image.color.a * 255;
    }
    public void uChange()
    {
        lens.transform.position = new Vector3(lens.transform.position.x, lens.transform.position.y, -20 + uSlider.value);
        uSliderText.text = (25 + uSlider.value).ToString("f1") + " cm";
    }
    public void setU()
    {
        uSlider.interactable = false;
        vSlider.interactable = true;
        u = 100 - uSlider.value;
        correctValue = (u * f) / (u - f);
    }
    public void recordResult()
    {
        uResults[count] = u;
        vResults[count] = v;
        count++;
        Debug.Log("Result " + count + " recorded");
        vSlider.interactable = false;
        uSlider.interactable = true;
    }
    public void vChange()
    {
        screen.transform.position = new Vector3(screen.transform.position.x, screen.transform.position.y,85 - (vSlider.value));
        Beam.transform.position = new Vector3(Beam.transform.position.x, Beam.transform.position.y, 10 - (0.5f*vSlider.value));
        Beam.transform.localScale = new Vector3(Beam.transform.localScale.x, 75 - (vSlider.value*0.5f), Beam.transform.localScale.z);
        vSliderText.text = (55 - (vSlider.value * 2)).ToString("f1") + " cm";
    }
    public void OnGUI()
    {
        if (UI.isOn == true)
        {
            rs.TwoResults("Distance U (cm)", "Distance V (cm)", uResults, vResults, count);
        }
    }
}
