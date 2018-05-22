using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level12 : Level12Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion

    Hotspots hotspot2;

    Element[] levers;

    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        camMain = Camera.main;
        newCamPosition = camMain.transform;

        hotspot2 = new Hotspots(2);

        levers = new Element[] { L1, L2, L3, L4, L5};

        foreach (Element l in levers)
        {
            l.elementMove = Element.ElementMove.y;
        }

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

        if (player.interact == PuzzleArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camPuzzle.transform);
        }
        if (camPuzzle.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camPuzzle.transform, camMain.transform);
        }

        if (player.interact == HintArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camHint.transform);
        }
        if (camHint.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camHint.transform, camMain.transform);
        }



        foreach (Element l in levers)
        {
            if (!l.isInteract)
                Level.MoveToHotspot(l, hotspot2, Level.GetCurrentHotspot(l, hotspot2));

        }

        if (Level.GetCurrentHotspot(L1, hotspot2) == 0
            && Level.GetCurrentHotspot(L2, hotspot2) == 1
            && Level.GetCurrentHotspot(L3, hotspot2) == 0
            && Level.GetCurrentHotspot(L4, hotspot2) == 1
            && Level.GetCurrentHotspot(L5, hotspot2) == 1 && !L1.isInteract && !L2.isInteract&& !L3.isInteract && !L4.isInteract && !L5.isInteract)
        {
            L1.canInteract = L2.canInteract = L3.canInteract = L4.canInteract = L5.canInteract = false;

            if (Level.Stamp(Bridge, .5f))
                Level.PushCamera(camPuzzle.transform, camMain.transform);
        }
        //else
        //{
        //    Level.Stamp(Bridge, -.5f);
        //}


        if (Input.GetMouseButton(0))
        {
            foreach (Element l in levers)
            {
                if (l.isInteract)
                    Level.MoveTowards(l, l.animValue - l.angleFromStart, 2);
            }
        }

        if (player.interact == LeverArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.Stamp(LeverBridge, 2);
        }

        if (LeverBridge.wasStamped)
        {
            Level.Stamp(BridgeLever, .5f);
        }

        if (player.interact == portal)
        {
            StartCoroutine(NextLevel());
        }
        
    }

    public IEnumerator NextLevel()
    {
        ImageFade fade = GameObject.FindObjectOfType<ImageFade>();
        fade.FadeImage(false);
        yield return null;
        SceneManager.LoadScene("Level3");
    }
}
