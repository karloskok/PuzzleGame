using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNew : MonoBehaviour {

	public Animator CameraObject;
	
	public GameObject PanelGame;
	
	public GameObject hoverSound;
	public GameObject sfxhoversound;
	public GameObject clickSound;
	public GameObject areYouSure;

	// campaign button sub menu
	public GameObject continueBtn;
	public GameObject newGameBtn;

	// highlights
	public GameObject lineGame;
    public GameObject playHighlights;
    public GameObject exitHighlights;

    // Panel settings
    public GameObject settingsPanel;
    public GameObject menuPanel;

    // InGameMenu koji koristi audio za settings i 
    public AudioSource inGameMenuSound;

    private bool settingsInGame=false;

    public void  PlayCampaign (){
		areYouSure.gameObject.active = false;
		continueBtn.gameObject.active = true;
		newGameBtn.gameObject.active = true;

        playHighlights.gameObject.active = true;
        exitHighlights.gameObject.active = false;
    }

	public void  DisablePlayCampaign (){
		continueBtn.gameObject.active = false;
		newGameBtn.gameObject.active = false;

        playHighlights.gameObject.active = false;
    }

	public void  Position2 (){
		DisablePlayCampaign();
        if (!CameraObject) return;
		CameraObject.SetFloat("Animate",1);
	}

	public void  Position1 (){
        if (!CameraObject) return;
        CameraObject.SetFloat("Animate",0);
	}

	public void  GamePanel (){
		PanelGame.gameObject.active = true;
		lineGame.gameObject.active = true;
	}

	public void  PlayHover (){
		hoverSound.GetComponent<AudioSource>().Play();
	}

	public void  PlayClick (){
		clickSound.GetComponent<AudioSource>().Play();
	}

	public void  AreYouSure (){
        exitHighlights.gameObject.active = true;
        areYouSure.gameObject.active = true;
		DisablePlayCampaign();
	}

	public void  No (){
        exitHighlights.gameObject.active = false;
        areYouSure.gameObject.active = false;
	}

	public void  Yes (){
        Application.Quit();
	}

    public void ContinueGame()
    {
        Debug.Log("Ucitavanje igre");
        // Ucitavanje igre
    }

    public void NewGame()
    {
        Debug.Log("Nova igra");
        SceneManager.LoadScene(1);
        // Ucitavanje igre
    }

    public void LoadGame()
    {
        Debug.Log("Ucitavanje snimljene igre");
        // Ucitavanje snimljene igre
    }

    public void ToggleSettingsInGame()
    {
        // Prikazi game menu
        if (!settingsInGame)
        {
            settingsInGame = true;
            settingsPanel.gameObject.active = true;
            menuPanel.gameObject.active = false;
        }
        else // Sakri game menu
        {
            settingsInGame = false;
            settingsPanel.gameObject.active = false;
            menuPanel.gameObject.active = true;
        }
    }
}