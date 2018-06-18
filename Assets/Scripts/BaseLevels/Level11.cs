using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
       // if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        camMain = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
      //  if (!EditorApplication.isPlaying) return;

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

        if (player.interact == Restart)
        {
            StartCoroutine(NextLevel(false));
        }

        if (Lever.wasStamped)
        {
            if(Level.Stamp(Bridge, .2f))
                if(!MusicPlayer.instance.efxSource.isPlaying)
                    MusicPlayer.instance.PlaySingle("bridge");
        }

        if(player.interact == portal)
        {
            StartCoroutine(NextLevel());
        }
        
    }

    public IEnumerator NextLevel(bool next = true)
    {
        ImageFade fade = GameObject.FindObjectOfType<ImageFade>();
        fade.FadeImage(false);
        if (next)
        { 
            yield return null;
            SceneManager.LoadScene("Level2");
        }
        else
        {
            yield return null;
            SceneManager.LoadScene("Level1");
        }
    }
}
