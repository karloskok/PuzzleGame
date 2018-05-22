using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StefControllerScript : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartButton()
    {
        anim.SetBool("PlayButton", true);
        anim.SetBool("ExitButton", false);

    }

    public void ExitButton()
    {
        anim.SetBool("ExitButton", true);
        anim.SetBool("PlayButton", false);
    }

    public void RestartTriggers()
    {
        anim.SetBool("PlayButton", false);
        anim.SetBool("ExitButton", false);
    }


}
