using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewtonScript : MonoBehaviour {
    public GameObject weight,gliderWeight;
    public Text newtonText;
    public AandFGliderScript glider;
    private float newton;
    private Rigidbody weightRB;
    private Vector3 startPosition;
    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        newton = 10;
        AdjustWeights();
        weightRB = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (glider.IsMoving())
        {
            weightRB.constraints = RigidbodyConstraints.None;
            weightRB.AddForce(0, -newton*3, 0, ForceMode.Acceleration);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && newton > 1)
            {
                newton = newton - 1;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && newton < 10)
            {
                newton = newton + 1;
            }
            AdjustWeights();
        }
    }
    public float GetNewtons()
    {
        return newton;
    }
    public void ResetPosition()
    {
        transform.position = startPosition;
        weightRB.constraints = RigidbodyConstraints.FreezePositionY;
        if (newton > 1)
        {
            newton = newton - 1;
        }
    }
    private void AdjustWeights()
    {
        weight.transform.localScale = new Vector3(weight.transform.localScale.x, 7 - 0.7f * (10-newton), weight.transform.localScale.z);
        weight.transform.localPosition = new Vector3(weight.transform.localPosition.x, 8 - 0.7f * (10 - newton), weight.transform.localPosition.z);
        gliderWeight.transform.localScale = new Vector3(gliderWeight.transform.localScale.x, 0.3f * (10 - newton), gliderWeight.transform.localScale.z);
        newtonText.text = " Force = " + newton + " N";
    }
    private void OnMouseDown()
    {
        glider.ClickSystem();
    }
}
