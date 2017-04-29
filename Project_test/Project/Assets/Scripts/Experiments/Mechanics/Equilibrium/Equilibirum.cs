using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Equilibirum : MonoBehaviour {
    public GameObject weight1,weight2,weight3,weight4,newtonGauge1,newtonGauge2,gaugeLevel1,gaugeLevel2;
    public Material stringMaterial;
    public Text gauge1Text,gauge2Text,clockwiseMoments0,clockwiseMoments50,clockwiseMoments75, anticlockwiseMoments0, anticlockwiseMoments50, anticlockwiseMoments75, error;
    public CanvasGroup resultsGroup,instructionsGroup;
    private float w1,w2,w3,w4,ng1,ng2,x,y,c;
    private bool results,instructions;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Equation();
        if (Input.GetKeyDown(KeyCode.R))
        {
            results = !results;
            instructions = false;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            instructions = !instructions;
            results = false;
        }
        if (results)
        {
            resultsGroup.alpha = 1;
            DisplayResults();
        }
        else
        {
            resultsGroup.alpha = 0;
        }
        if(instructions)
        {
            instructionsGroup.alpha = 1;
        }
        else
        {
            instructionsGroup.alpha = 0;
        }
    }
    private void Equation()
    {
        w1 = ((weight1.transform.position.x + 75) / 1.5f)*0.01f;
        w2 = ((weight2.transform.position.x + 75) / 1.5f) * 0.01f;
        w3 = ((weight3.transform.position.x + 75) / 1.5f) * 0.01f;
        w4 = ((weight4.transform.position.x + 75) / 1.5f) * 0.01f;
        ng1 = ((newtonGauge1.transform.position.x + 75) / 1.5f) * 0.01f;
        ng2 = ((newtonGauge2.transform.position.x + 75) / 1.5f) * 0.01f;
        c = (w1*2) + (w2) + (w3*3) + (w4*2)+(0.5f);//Clockwise monets about the 0cm mark of the ruler. The w correspond to the distance of the weight from the 0cm point. The other number is the force the weight is appling in newtons. The 0.5 corresponds to the force of the ruler(1N * 0.5cm).
        y = (c - (ng1 * 9)) / (ng2 - ng1);//The upward force being applied on the first newton gauge in Newtons.
        if (y <= 0 || y >= 9)
        {
            error.text = "Object not in Equilibrium please adjust weights or newton gauges.";
        }
        else
        {
            error.text = "";
        }
        x = 9 - y;//The upward force being applied on the second newton gauge in newtons. Found as upward forces must = downward forces.
        gauge1Text.text ="Newton Gauge 1 (Force) :"+x.ToString("f1") + " N";
        gauge2Text.text = "Newton Gauge 2 (Force) :" + y.ToString("f1") + " N";
        gaugeLevel1.transform.localPosition = new Vector3(0, 0.5f, (x*0.8f)-3.8f);
        gaugeLevel2.transform.localPosition = new Vector3(0, 0.5f, (y * 0.8f) - 3.8f);
    }
    private void DisplayResults()
    {
        float[] moments0 = CalcMoments(0);
        float []moments50 =CalcMoments(0.5f);
        float[] moments75 = CalcMoments(0.75f);
        clockwiseMoments0.text = "Clockwise Moments about 0cm mark : " +moments0[0].ToString("f3")+"N";
        anticlockwiseMoments0.text = "Antilockwise Moments about 0cm mark : " + moments0[1].ToString("f3") + "N";
        clockwiseMoments50.text = "Clockwise Moments about 50cm mark : " + moments50[0].ToString("f3") + "N";
        anticlockwiseMoments50.text = "Anticlockwise Moments about 50cm mark : " + moments50[1].ToString("f3") + "N";
        clockwiseMoments75.text = "Clockwise Moments about 75cm mark : " + moments75[0].ToString("f3") + "N";
        anticlockwiseMoments75.text = "Anticlockwise Moments about 75cm mark : " + moments75[1].ToString("f3") + "N";
    }
    private float[] CalcMoments(float f)//Method calculates moments about a point on the ruler. Float paratmeter must be between 0-1 inclusive. Array of size 2 returned containing clockwise moments at position [0] and anticlockwise moments at position [1].
    {
        float clockwise=0;
        float anticlockwise=0;
        float[] allDistances = {w1,w2,w3,w4,ng1,ng2,0.5f};
        float[] allForces = { 2, 1, 3, 2, -x, -y, 1 };
        for(int i = 0; i < 7; i++)
        {
            if (allDistances[i] > f)
            {
                if (allForces[i] > 0)
                {
                    clockwise = clockwise + ((allDistances[i]-f)*allForces[i]);
                }
                else
                {
                    anticlockwise = anticlockwise + ((allDistances[i] - f) * Mathf.Abs(allForces[i]));
                }
            }
            else
            {
                if (allForces[i] > 0)
                {
                    anticlockwise = anticlockwise + ((f-allDistances[i]) * allForces[i]);
                }
                else
                {
                    clockwise = clockwise + ((f-allDistances[i]) * Mathf.Abs(allForces[i]));
                }
            }
        }
        float[] a = { clockwise,anticlockwise };
        return a;
    }
}
