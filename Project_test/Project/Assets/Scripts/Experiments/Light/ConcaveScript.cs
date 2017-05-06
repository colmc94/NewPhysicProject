using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConcaveScript : MonoBehaviour {
    public OldResultScript rs;
    public Material image;
    public Text test,test1,uSliderText,vSliderText;
    public Slider uSlider,vSlider;
    public GameObject mirror,vBeam,uBeam,screen,screenDispaly;
    public Toggle UI;
    private float a,r,g,b,sqrtHalf,u,v,f,correctValue,difference;
    private Vector3 vPos,screenPos, screenDisplayPos;
    private float[] uResults,vResults;
    private int count;
	// Use this for initialization
	void Start () {
        image.color = new Color(1,1,1, 0);
        sqrtHalf = Mathf.Sqrt(0.5f);
        f = 20;
        screenDisplayPos = Camera.main.ScreenToWorldPoint(new Vector3(100, 100, 200));
        screenDispaly.transform.position = screenDisplayPos;
        uResults = new float[10];
        vResults = new float[10];
        vPos = new Vector3(vBeam.transform.position.x, vBeam.transform.position.y, vBeam.transform.position.z + uSlider.value);
        screenPos = new Vector3(screen.transform.position.x, screen.transform.position.y, screen.transform.position.z + uSlider.value);
    }
	
	// Update is called once per frame
	void Update () {
        if(vSlider.interactable == true)
        {
            v = 40 + (vSlider.value * 2);
            difference = Mathf.Abs(v - correctValue);
            image.color = new Color(image.color.r, image.color.g, image.color.b, (255-difference*30)/255);
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
        if (Input.GetKey(KeyCode.RightArrow)&&uSlider.interactable)
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
        test.text = "u slider: " + (vPos.z - uSlider.value)+" v slider: "+ (vPos.z - (vSlider.value * sqrtHalf)+" actual position : "+vBeam.transform.position.z);
        test1.text = "u = " + u.ToString("f1")+ " v = " + v+ " real v = " + correctValue.ToString("f2")+ " a = " + image.color.a*255;
    }
    public void uChange()
    {
        mirror.transform.position = new Vector3(mirror.transform.position.x, mirror.transform.position.y, 75 - uSlider.value);
        screen.transform.position = new Vector3(screen.transform.position.x, screen.transform.position.y, screenPos.z - uSlider.value);
        vBeam.transform.position = new Vector3(vBeam.transform.position.x, vBeam.transform.position.y, vPos.z - uSlider.value);
        uBeam.transform.position = new Vector3(uBeam.transform.position.x, uBeam.transform.position.y, 6 - (uSlider.value*0.5f));
        uBeam.transform.localScale = new Vector3(uBeam.transform.localScale.x, 70 - (uSlider.value*0.5f), uBeam.transform.localScale.z);
        uSliderText.text = (100 - uSlider.value).ToString("f1") + " cm";
    }
    public void setU()
    {
        vPos = new Vector3(vBeam.transform.position.x, vBeam.transform.position.y, vBeam.transform.position.z+(vSlider.value*sqrtHalf));
        screenPos = new Vector3(screen.transform.position.x, screen.transform.position.y, screen.transform.position.z+(vSlider.value*1.4f));
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
        vPos = new Vector3(vBeam.transform.position.x, vBeam.transform.position.y, vBeam.transform.position.z+uSlider.value);
        screenPos = new Vector3(screen.transform.position.x, screen.transform.position.y, screen.transform.position.z+uSlider.value);
    }
    public void vChange()
    {
        screen.transform.position = new Vector3(17.5f + (vSlider.value*1.4f), screenPos.y, screenPos.z - (vSlider.value*1.4f));
        vBeam.transform.position = new Vector3(-0.1f+(vSlider.value*sqrtHalf), vPos.y, vPos.z - (vSlider.value*sqrtHalf));
        vBeam.transform.localScale = new Vector3(vBeam.transform.localScale.x, 24+ (vSlider.value ), vBeam.transform.localScale.z);
        vSliderText.text = (40 + (vSlider.value*2)).ToString("f1") + " cm";
    }
    public void OnGUI()
    {
        if (UI.isOn == true)
        {
            rs.TwoResults("Distance U (cm)", "Distance V (cm)", uResults, vResults, count);
        }
    }
}
