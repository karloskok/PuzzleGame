using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void continueButton()
    {
        Debug.Log("Igra se nastavlja");
    }

    public void newGameButton()
    {
        SceneManager.LoadScene("Intro");
    }

    public void areYouSureYesButton()
    {
        Application.Quit();
    }

    public void playSound()
    {

    }


}
