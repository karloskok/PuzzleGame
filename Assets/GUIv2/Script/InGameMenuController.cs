using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuController : MonoBehaviour {

    public GameObject MenuCanvas;
    public GameObject inGameMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject levelSelector;
    public GameObject areYouSure;
    public Button continueButton;

    // Koristi se za shadow
    public Light sunce;

    // SETTINGS PANEL
    public Button toggleShadow;
    private int Shadow;
    public static bool glavniIzbornik;

    public GameObject rezolucija960;
    public GameObject rezolucija1280;
    public GameObject rezolucija1920;
    public GameObject rezolucijaFull;

    // Slider
    public Slider sliderSound;
    public int[] screenWidths;
    private int indexResoultion;
    private int lastLevel;

    // Button levels
    public Button[] levelButtons;

    private void Start()
    {
        Shadow = PlayerPrefs.GetInt("Shadow",0);
        ToggleShadow();

        glavniIzbornik = false;

        sliderSound.value = PlayerPrefs.GetFloat("SoundVolume_value", 1);
        
        // Postavljanje rezolucije
        SetResolution(PlayerPrefs.GetInt("Index_resolution", 3));

        // Postavljanje muzike u sceni na pocetnu
        AudioListener.volume = sliderSound.value;
        lastLevel = PlayerPrefs.GetInt("LastLevel", 0);

        // SetVisible levele
        for(int i = 0; i < 5; ++i)
        {
            if (i <= lastLevel)levelButtons[i].interactable = true;
            else levelButtons[i].interactable = false; 
        }

        if (lastLevel < 1 && continueButton != null) continueButton.interactable = false;
        else if (continueButton != null) continueButton.interactable = true;
    }

    private void Update()
    {

    }

    public void ClickContinueButton()
    {
        Time.timeScale = 1;
        inGameMenuCanvas.SetActive(true);
        // Iskljucivanje nepotrebnih panela
        settingsCanvas.SetActive(false);
        levelSelector.SetActive(false);
        areYouSure.SetActive(false);
        MenuCanvas.SetActive(false);
    }

    public void ClickNewGameButton()
    {
        levelSelector.SetActive(!levelSelector.activeSelf);
        // Iskljucivanje nepotrebnih panela
        areYouSure.SetActive(false);
    }

    public void ClickLevelButton(string level)
    {
        // Ucitati određenu scenu

        // Iskljucivanje nepotrebnih panela
        levelSelector.SetActive(false);
        areYouSure.SetActive(false);
    }

    public void ClickSettings()
    {
        settingsCanvas.SetActive(true);
        
        // Iskljucivanje nepotrebnih panela
        inGameMenuCanvas.SetActive(false);
        levelSelector.SetActive(false);
        areYouSure.SetActive(false);
    }

    public void ClickSettingsReturn()
    {
        settingsCanvas.SetActive(false);
        inGameMenuCanvas.SetActive(true);

        PlayerPrefs.SetFloat("SoundVolume_value", sliderSound.value);
        PlayerPrefs.Save();
    }

    public void ClickExit()
    {
        // Iskljucivanje nepotrebnih panela
        levelSelector.SetActive(false);
        areYouSure.SetActive(true);
    }

    public void ClickYes() {
        
        settingsCanvas.SetActive(false);
        inGameMenuCanvas.SetActive(true);

        Application.Quit();
    }

    public void ClickNo() {
        areYouSure.SetActive(false);
    }

    // SETTINGS PANEL
    
    public void ToggleShadow()
    {
        if (Shadow == 0)
        {
            toggleShadow.GetComponentInChildren<Text>().text = "OFF";
            sunce.shadowStrength = 0;
            Shadow = 1;
            PlayerPrefs.SetInt("Shadow", 0);
        }
        else if (Shadow == 1)
        {
            toggleShadow.GetComponentInChildren<Text>().text = "ON";
            sunce.shadowStrength = 1;
            Shadow = 0;
            PlayerPrefs.SetInt("Shadow", 1);
        }
    }

    public void SliderSound()
    {
        AudioListener.volume = sliderSound.value;
    }

    
    public void SetResolution(int i)
    {
        float aspectRatio = 16 / 9;
        if (i == 0)
        {
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);

            // Postavljanje headlight
            rezolucija960.active = true;
            rezolucija1280.active = false;
            rezolucija1920.active = false;
            rezolucijaFull.active = false;
        }
        else if (i == 1)
        {
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);

            // Postavljanje headlight
            rezolucija960.active = false;
            rezolucija1280.active = true;
            rezolucija1920.active = false;
            rezolucijaFull.active = false;
        }
        else if (i == 2)
        {
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);

            // Postavljanje headlight
            rezolucija960.active = false;
            rezolucija1280.active = false;
            rezolucija1920.active = true;
            rezolucijaFull.active = false;
        }
        else
        {
            Resolution[] allResolution = Screen.resolutions;
            Resolution maxResolution = allResolution[allResolution.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);

            // Postavljanje headlight
            rezolucija960.active = false;
            rezolucija1280.active = false;
            rezolucija1920.active = false;
            rezolucijaFull.active = true;
        }

        PlayerPrefs.SetInt("Index_resolution", i);
        PlayerPrefs.Save();
    }

    // Load Levels
    public void LoadLevel(int i)
    {
        if (i == 11) i = lastLevel;
        switch (i)
        {
            case 0:
                SceneManager.LoadScene("Level21");
                break;
            case 1:
                SceneManager.LoadScene("Level22");
                break;
            case 2:
                SceneManager.LoadScene("Level23");
                break;
            case 3:
                SceneManager.LoadScene("Level24");
                break;
            case 4:
                SceneManager.LoadScene("Level25");
                break;

            case -1:
                SceneManager.LoadScene("ComicIntro");
                break;
        }
    }
}

