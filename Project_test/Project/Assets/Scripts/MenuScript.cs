using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void VandAExp()
    {
        SceneManager.LoadScene("VandA");
    }
    public void FandAExp()
    {
        SceneManager.LoadScene("FandA");
    }
    public void MomentumExp()
    {
        SceneManager.LoadScene("Momentum");
    }
    public void GravityExp()
    {
        SceneManager.LoadScene("Gravity");
    }
    public void BoylesExp()
    {
        SceneManager.LoadScene("Boyles");
    }
    public void PendulumExp()
    {
        SceneManager.LoadScene("Pendulum");
    }
}
