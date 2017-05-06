using UnityEngine;
using System.Collections;

public class LightGateScript : MonoBehaviour
{
    public TimerScript timeScript;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider otherInfo)
    {
        timeScript.StartTimer();
    }
    void OnTriggerExit(Collider other)
    {
        timeScript.StopTimer();
    }
}
