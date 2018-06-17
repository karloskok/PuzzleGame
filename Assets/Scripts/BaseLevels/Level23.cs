using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level23 : Level23Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion


    Element[] buttons, sliders, rotFirst, rotSecond, rotThird;
    float[] correctButtons1;
    Hotspots hotspot4, hotspot5;


    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;

        if (PlayerPrefs.GetInt("LastLevel", 0) < 2) PlayerPrefs.SetInt("LastLevel", 2);
        if (PlayerPrefs.GetInt("Shadow") == 1) // InGameMenuController.sunce.shadowStrength = 1;

        player = PlayerInteract.instance;

        //Hover.elementMove = Element.ElementMove.y;
        //LeftHandle.elementMove = Element.ElementMove.y;
        //RightHandle.elementMove = Element.ElementMove.y;
        hotspot4 = new Hotspots(4);
        hotspot5 = new Hotspots(5);

        buttons = new Element[] { B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, B16 };
        correctButtons1 = new float[] { 1, 0, 0, 1,
                                        0, 1, 0, 0,
                                        0, 0, 1, 0,
                                        0, 0, 0, 0};

        sliders = new Element[] { P1, P2, P3, P4 };
        foreach (Element l in sliders)
        {
            l.elementMove = Element.ElementMove.y;
        }

        rotFirst = new Element[] { FR1, FR2 };
        foreach (Element b in rotFirst)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(FR1, hotspot5, 3);
        Level.SetToHotspot(FR2, hotspot5, 1);

        rotSecond = new Element[] { SR1, SR2, SR3, SR4};
        foreach (Element b in rotSecond)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(SR1, hotspot5, 2);
        Level.SetToHotspot(SR2, hotspot5, 3);
        Level.SetToHotspot(SR3, hotspot5, 3);
        Level.SetToHotspot(SR4, hotspot5, 1);

        rotThird = new Element[] { TR1, TR2, TR3, TR4};
        foreach (Element b in rotThird)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(TR1, hotspot5, 3);
        Level.SetToHotspot(TR2, hotspot5, 1);
        Level.SetToHotspot(TR3, hotspot5, 1);
        Level.SetToHotspot(TR4, hotspot5, 1);


        foreach (Element b in buttons)
        {
            b.stampMaterial = -1;
        }


        ButtonArea.isActive = false;
        SecondArea.isActive = false;
        ThirdArea.isActive = false;

        camMain = Camera.main;

    }

    // Update is called once per frame

    void Update()
    {
        if (Time.frameCount % 3 == 0)
        {



            if (!EditorApplication.isPlaying) return;

            if (!camMain.enabled)
            {
                player.GetComponent<Movement>().enabled = false;
            }
            else
                player.GetComponent<Movement>().enabled = true;


            //puzzle01
            if (player.interact == StartArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, StartCam.transform);
            }

            if (StartCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(StartCam.transform, camMain.transform);
            }


            //puzzleRotFirst
            if (player.interact == FirstArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, FirstCam.transform);
            }

            if (FirstCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(FirstCam.transform, camMain.transform);
            }

            //puzzleRotsecond
            if (player.interact == SecondArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, SecondtCam.transform);
            }

            if (SecondtCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(SecondtCam.transform, camMain.transform);
            }

            //puzzleRotthird
            if (player.interact == ThirdArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, ThirdCam.transform);
            }

            if (ThirdCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(ThirdCam.transform, camMain.transform);
            }

            //puzzleButtons
            if (player.interact == ButtonArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, ButtonCam.transform);
            }

            if (ButtonCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(ButtonCam.transform, camMain.transform);
            }


            foreach (Element l in sliders)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot4, Level.GetCurrentHotspot(l, hotspot4));

            }

            foreach (Element l in rotFirst)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot5, Level.GetCurrentHotspot(l, hotspot5));

            }
            if (Level.GetCurrentHotspot(FR1, hotspot5) == 0
                && (Level.GetCurrentHotspot(FR2, hotspot5) == 0 || Level.GetCurrentHotspot(FR2, hotspot5) == 2 || Level.GetCurrentHotspot(FR2, hotspot5) == 4)
                && !FR1.isInteract && !FR2.isInteract)
            {
                //P1.canInteract = P2.canInteract = P3.canInteract = P4.canInteract = false;
                SecondArea.isActive = true;
                SecondArea.gameObject.SetActive(true);
                if (Level.Stamp(SecondHover, .5f) && !SecondHover.wasStamped)
                {

                    Level.PushCamera(FirstCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }

            }

            foreach (Element l in rotSecond)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot5, Level.GetCurrentHotspot(l, hotspot5));

            }
            if (Level.GetCurrentHotspot(SR1, hotspot5) == 0
                && (Level.GetCurrentHotspot(SR2, hotspot5) == 0 || Level.GetCurrentHotspot(SR2, hotspot5) == 2 || Level.GetCurrentHotspot(SR2, hotspot5) == 4)
                && Level.GetCurrentHotspot(SR3, hotspot5) == 0
                && (Level.GetCurrentHotspot(SR4, hotspot5) == 0 || Level.GetCurrentHotspot(SR4, hotspot5) == 2 || Level.GetCurrentHotspot(SR4, hotspot5) == 4)
                && !SR1.isInteract && !SR2.isInteract && !SR3.isInteract && !SR4.isInteract)
            {
                //P1.canInteract = P2.canInteract = P3.canInteract = P4.canInteract = false;

                if (Level.Stamp(ThirdHover, .5f))
                {
                    ThirdArea.isActive = true;
                    ThirdArea.gameObject.SetActive(true);
                    Level.PushCamera(SecondtCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }

            }

            foreach (Element l in rotThird)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot5, Level.GetCurrentHotspot(l, hotspot5));

            }

            if ((Level.GetCurrentHotspot(TR1, hotspot5) == 0 || Level.GetCurrentHotspot(TR1, hotspot5) == 4)
               && (Level.GetCurrentHotspot(TR2, hotspot5) == 0 || Level.GetCurrentHotspot(TR2, hotspot5) == 2 || Level.GetCurrentHotspot(TR2, hotspot5) == 4)
               && (Level.GetCurrentHotspot(TR4, hotspot5) == 0 || Level.GetCurrentHotspot(TR4, hotspot5) == 4)
               && (Level.GetCurrentHotspot(TR3, hotspot5) == 0 || Level.GetCurrentHotspot(TR3, hotspot5) == 2 || Level.GetCurrentHotspot(TR3, hotspot5) == 4)
               && !TR1.isInteract && !TR2.isInteract && !TR3.isInteract && !TR4.isInteract)
            {
                //P1.canInteract = P2.canInteract = P3.canInteract = P4.canInteract = false;
                ButtonArea.isActive = true;
                ButtonArea.gameObject.SetActive(true);
                if (Level.Stamp(Opener1, .5f))
                {

                    Level.Stamp(Opener2, .5f);

                    Level.PushCamera(ThirdCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }

            }
            if (Opener1.wasStamped)
            {
                if (Level.Stamp(FinalHolder, .5f))
                {
                    ButtonArea.isActive = true;
                    //
                }
            }


            if (Level.GetCurrentHotspot(P1, hotspot4) == 3
                && Level.GetCurrentHotspot(P2, hotspot4) == 2
                && Level.GetCurrentHotspot(P3, hotspot4) == 1
                && Level.GetCurrentHotspot(P4, hotspot4) == 3
                && !P1.isInteract && !P2.isInteract && !P3.isInteract && !P4.isInteract)
            {
                P1.canInteract = P2.canInteract = P3.canInteract = P4.canInteract = false;

                if (Level.Stamp(StartBridge, .5f))
                {
                    Level.PushCamera(StartCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }

            }

            bool firstPuzzle = true;
            for (int i = 0; i < correctButtons1.Length; i++)
            {
                if (buttons[i].animValue != correctButtons1[i]) firstPuzzle = false;
            }
            if (firstPuzzle)
            {
                if (Level.Stamp(PortalBridge))
                {
                    Level.PushCamera(ButtonCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }
            }

            if (player.interact == Restart)
            {
                StartCoroutine(NextLevel(false));
            }



            if (player.interact == portal)
            {
                StartCoroutine(NextLevel());
            }


        }

        if (Input.GetMouseButton(0))
            {

                foreach (Element b in buttons)
                {
                    if (b.isInteract)
                    {
                        Level.Stamp(b, b.animValue < .5f ? 1 : -1);
                    }
                }


                foreach (Element l in sliders)
                {
                    if (l.isInteract)
                        Level.MoveTowards(l, l.animValue + l.angleFromStart, 1.8f);
                }

                foreach (Element l in rotFirst)
                {
                    if (l.isInteract)
                        Level.MoveTowards(l, l.angleFromStart > 0 ? l.animValue + l.angleFromStart : l.animValue, .8f);

                }

                foreach (Element l in rotSecond)
                {
                    if (l.isInteract)
                        Level.MoveTowards(l, l.angleFromStart > 0 ? l.animValue + l.angleFromStart : l.animValue, .8f);
                }
                foreach (Element l in rotThird)
                {
                    if (l.isInteract)
                        Level.MoveTowards(l, l.angleFromStart > 0 ? l.animValue + l.angleFromStart : l.animValue, .8f);
                }

            }

            
        

    }

    public IEnumerator NextLevel(bool next = true)
    {
        ImageFade fade = GameObject.FindObjectOfType<ImageFade>();
        fade.FadeImage(false);
        if (next)
        { 
            yield return null;
            SceneManager.LoadScene("Level24");
        }
        else
        {
            yield return null;
            SceneManager.LoadScene("Level23");
        }
    }
}
