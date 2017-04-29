using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FandAScript : MonoBehaviour
{
    public GameObject s1, f1, s2, f2,normal,weight;
    public ResultsScript rs;
    public Rigidbody vehicle;
    public Text /*time1Text,time2Text,v1Text,v2Text,accelerationText*/forceSliderText, timeSliderText;
    public Toggle UI;
    public Slider forceSlider, timeSlider;
    public Material white;
    private Rigidbody card;
    private LineRenderer lr1, lr2;
    private int count, num;
    private float time1, time2, velocity1, velocity2, acceleration, w, h;
    private Vector3 cardPosition, vehiclePosition,weightPosition;
    private float[] time1Results, time2Results, velocity1Results, velocity2Results, accelerationResults;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = timeSlider.value / 10;
        Physics.gravity = new Vector3(0, 0, forceSlider.value);
        vehicle.useGravity = false;
        card = GetComponent<Rigidbody>();
        cardPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        vehiclePosition = new Vector3(vehicle.transform.position.x, vehicle.transform.position.y, vehicle.transform.position.z);
        weightPosition = new Vector3(weight.transform.position.x, weight.transform.position.y, weight.transform.position.z);
        time1Results = new float[10];
        time2Results = new float[10];
        velocity1Results = new float[10];
        velocity2Results = new float[10];
        accelerationResults = new float[10];
        num = 0;
        w = 1920f;
        h = 1080;
        lr1 = s1.AddComponent<LineRenderer>();
        lr2 = s2.AddComponent<LineRenderer>();
        lr1.material = white;
        lr2.material = white;
        lr1.SetColors(Color.yellow, Color.yellow);
        lr2.SetColors(Color.yellow, Color.yellow);
        lr1.SetWidth(0.5f, 0.5f);
        lr2.SetWidth(0.5f, 0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        weight.transform.position = new Vector3(weightPosition.x, weightPosition.y-(Mathf.Abs(cardPosition.z - transform.position.z)), weightPosition.z);
        lr1.SetPosition(0, s1.transform.position);
        lr1.SetPosition(1, f1.transform.position);
        lr2.SetPosition(0, s2.transform.position);
        lr2.SetPosition(1, f2.transform.position);
        if (transform.position.z >= 55)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 55f);
            vehicle.transform.position = new Vector3(vehicle.transform.position.x, vehicle.transform.position.y, 58.5f);
        }
    }
    public void StartExp()
    {
        vehicle.useGravity = true;
        card.useGravity = true;
    }
    public void ResetExp()
    {
        StoreResults();
        vehicle.useGravity = false;
        card.useGravity = false;
        card.velocity = new Vector3(0, 0, 0);
        vehicle.velocity = new Vector3(0, 0, 0);
        transform.position = cardPosition;
        vehicle.transform.position = vehiclePosition;
        count = 0;
        time1 = 0;
        time2 = 0;
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
        count++;
    }
    void OnTriggerStay(Collider other)
    {
        if (count == 1)
        {
            time1 = time1 + Time.fixedDeltaTime;
            //time1Text.text = "Time 1: " + time1.ToString("f4") + " s";
        }
        if (count == 2)
        {
            time2 = time2 + Time.fixedDeltaTime;
            //time2Text.text = "Time 2: " + time2.ToString("f4") + " s";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (count == 1)
        {
            velocity1 = 0.07f / time1;
            //v1Text.text = "Velocity 1 : " + velocity1.ToString("f4") + " m/s";
        }
        if (count == 2)
        {
            velocity2 = 0.07f / time2;
            //v2Text.text = "Velocity 2 : " + velocity2.ToString("f4") + " m/s";
            acceleration = ((velocity2 * velocity2) - (velocity1 * velocity1)) / 0.6f; //(v^2-u^2)/2s
            //accelerationText.text = "Acceleration : "+acceleration.ToString("f4")+" m/s^2";
        }
    }
    private void StoreResults()
    {
        time1Results[num] = time1;
        time2Results[num] = time2;
        velocity1Results[num] = velocity1;
        velocity2Results[num] = velocity2;
        accelerationResults[num] = acceleration;
        num++;
    }
    public void AdjustSpeed()
    {
        Time.timeScale = timeSlider.value / 10;
        timeSliderText.text = (timeSlider.value) / 10 + " X Speed";
    }
    public void AdjustForce()
    {
        Physics.gravity = new Vector3(0, 0, forceSlider.value);
        if (forceSlider.value > 6.6)
        {
            forceSliderText.text = "Hard Push";
        }
        else if (forceSlider.value < 3.3)
        {
            forceSliderText.text = "Soft Push";
        }
        else
        {
            forceSliderText.text = "Medium Push";
        }
    }
    public void OnGUI()
    {
        float ratioX = Screen.width / w;
        float ratioY = Screen.height / h;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(ratioX, ratioY, 1));
        if (UI.isOn == true)
        {
            rs.FiveColumns("Time 1(s)", "Time 2(s)", "Velocity 1(m/s)", "Velocity 2(m/s)", "Acceleration(m/s^2)", time1Results, time2Results, velocity1Results, velocity2Results, accelerationResults, num);
        }
    }
}
