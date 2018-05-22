using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level11 : Level11Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion

   


    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        camMain = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying) return;

        if (!camMain.enabled)
        {
            player.GetComponent<Movement>().enabled = false;
        }
        else
            player.GetComponent<Movement>().enabled = true;


        if (player.interact == LeverArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.Stamp(Lever, 2);
        }

        if (Lever.wasStamped)
        {
            Level.Stamp(Bridge);
        }

        if(player.interact == portal)
        {
            StartCoroutine(NextLevel());
        }
        
    }

    public IEnumerator NextLevel()
    {
        ImageFade fade = GameObject.FindObjectOfType<ImageFade>();
        fade.FadeImage(false);
        yield return null;
        SceneManager.LoadScene("Level2");
    }
}
