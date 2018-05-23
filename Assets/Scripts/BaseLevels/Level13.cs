﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level13 : Level13Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion

    Hotspots hotspot6;

    Element[] buttons, firstRotators;
    float[] correctButtons1, correctButtons2, correctButtons3;
    int[] correctRot1;

    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        camMain = Camera.main;
        newCamPosition = camMain.transform;

        hotspot6 = new Hotspots(7);

        buttons = new Element[] { B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, B16, B17, B18, B19, B20, B21, B22, B23, B24, B25 };

        correctButtons1 = new float[] { 0, 0, 0, 0, 0,
                                        0, 0, 0, 1, 0,
                                        0, 0, 1, 0, 0,
                                        0, 1, 0, 1, 0,
                                        0, 0, 0, 0, 0};

        correctButtons2 = new float[] { 0, 1, 1, 1, 0,
                                        0, 0, 1, 0, 0,
                                        0, 0, 1, 0, 0,
                                        0, 0, 1, 0, 0,
                                        1, 1, 1, 1, 1};

        correctButtons3 = new float[] { 1, 0, 1, 0, 1,
                                        0, 1, 1, 1, 0,
                                        0, 1, 0, 1, 0,
                                        0, 1, 1, 1, 0,
                                        1, 0, 0, 0, 1};

        correctRot1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        foreach (Element b in buttons)
        {
            b.stampMaterial = -1;
        }

        Hint2Area.isActive = false;

        //R11.wrapMode = WrapMode.Loop;
        //R11.elementMove = Element.ElementMove.x;
        //Level.SetWrapMode(R11, WrapMode.Loop);
        firstRotators = new Element[] { R11, R12, R13, R14, R15, R16, R17, R18, R19, R110, R111, R112, R113, R114, R115, R116 };
        foreach (Element r in firstRotators)
        {
            Level.SetWrapMode(r, WrapMode.Loop);
        }

        foreach (Element r in firstRotators)
        {
            int rand = Random.Range(0, 6);
            Level.SetToHotspot(r, hotspot6, rand);
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

        if (player.interact == Hint1Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camHint1.transform);
        }
        if (camHint1.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camHint1.transform, camMain.transform);
        }

        if (FirstPuzzleLeverDown.interact == FirstPuzzleCube || FirstPuzzleLeverDown == player.interact)
        {
            Level.Stamp(FirstBridge, .5f);
            Level.Stamp(FirstPuzzleLeverDown, 2f);
        }
        else
        {
            Level.Stamp(FirstBridge, -.25f);
            Level.Stamp(FirstPuzzleLeverDown, -2f);
        }


        if (player.interact == ButtonsArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camButtons.transform);
        }
        if (camButtons.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camButtons.transform, camMain.transform);
        }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (Element b in buttons)
            {
                if (b.isInteract)
                {
                    Level.Stamp(b, b.animValue < .5f ? 1 : -1);
                }
            }

        }
        bool firstPuzzle = true;
        for (int i = 0; i < correctButtons1.Length; i++)
        {
            if (buttons[i].animValue != correctButtons1[i]) firstPuzzle=false;
        }
        if (firstPuzzle)
        {
            if (Level.Stamp(RightBridge))
                Level.PushCamera(camButtons.transform, camMain.transform);
        }

        bool secondPuzzle = true;
        for (int i = 0; i < correctButtons2.Length; i++)
        {
            if (buttons[i].animValue != correctButtons2[i]) secondPuzzle = false;
        }
        if (secondPuzzle)
        {
            if (Level.Stamp(LeftBridge))
                Level.PushCamera(camButtons.transform, camMain.transform);
        }

        bool thirdPuzzle = true;
        for (int i = 0; i < correctButtons3.Length; i++)
        {
            if (buttons[i].animValue != correctButtons3[i]) thirdPuzzle = false;
        }
        if (thirdPuzzle)
        {
            if (Level.Stamp(PortalBridge))
                Level.PushCamera(camButtons.transform, camMain.transform);
        }


        if (player.interact == RotPuzzle1Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camRot1.transform);
        }
        if (camRot1.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camRot1.transform, camMain.transform);
        }



        foreach (Element r in firstRotators)
        {
            if (!r.isInteract)
                Level.MoveToHotspot(r, hotspot6, Level.GetCurrentHotspot(r, hotspot6));
        }



        // firstRotators
        if (Input.GetMouseButtonDown(0))
        {
            foreach (Element r in firstRotators)
            {
                if (r.isInteract)
                {
                    int val = Level.GetCurrentHotspot(r, hotspot6);
                    if (++val >= hotspot6.spots) val = 0;
                    Level.SetToHotspot(r, hotspot6, val);
                }
            }
        }

        bool firstRotTrue = true;
        foreach (Element r in firstRotators)
        {
            if (Level.GetCurrentHotspot(r, hotspot6) != 0)
                firstRotTrue = false;
        }

        if (firstRotTrue)
        {
            Hint2Area.isActive = true;
            Hint2Area.gameObject.SetActive(true);
            if (Level.Stamp(Hint2Lit, .5f))
            {
                Level.PushCamera(camRot1.transform, camMain.transform);
            }
        }

       
        if (player.interact == Hint2Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camHint2.transform);
        }
        if (camHint2.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camHint2.transform, camMain.transform);
        }

        //



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
        SceneManager.LoadScene("Level4");
    }
}
