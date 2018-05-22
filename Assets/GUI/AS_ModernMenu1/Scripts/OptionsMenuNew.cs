using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsMenuNew : MonoBehaviour {

	// toggle buttons
	public GameObject showhudtext;
	public GameObject tooltipstext;
	
	// sliders
	public GameObject musicSlider;
    public Text showHUD_txt;
    public Text showShadow_txt;

    // Boolean
    public bool showHUD_bool;
    public bool showShadow_bool;

    public float sliderValueMusic = 0.0f;

    public void Start()
    {
        showHUD_bool = true;
        showShadow_bool = true;
    }

    public void showHUD()
    {
        if (showHUD_bool) {
            showHUD_txt.text = "OFF";
            showHUD_bool = false;
            Debug.Log("OFF");
        }
        else {
            showHUD_txt.text = "ON";
            showHUD_bool = true;
            Debug.Log("ON");
        }
    }

    public void showShadow()
    {
        if (showShadow_bool)
        {
            showShadow_txt.text = "OFF";
            showShadow_bool = false;
            Debug.Log("OFF");
        }
        else
        {
            showShadow_txt.text = "ON";
            showShadow_bool = true;
            Debug.Log("ON");
        }
    }
}