using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level25 : Level25Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion


    Element[] firstRotators, secondRotators, buttons;
    float[] correctButtonsLeft1, corrLeftBridge1, corrLeftBridge2, corrLeftBridge3, corrRightBridge1, corrRightBridge2;
    Hotspots hotspot6;


    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        //Hover.elementMove = Element.ElementMove.y;
        //LeftHandle.elementMove = Element.ElementMove.y;
        //RightHandle.elementMove = Element.ElementMove.y;
        hotspot6 = new Hotspots(7);

        buttons = new Element[] { B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, B16, B17, B18, B19, B20, B21, B22, B23, B24, B25 };
        foreach (Element b in buttons)
        {
            if (b == B13) continue;
            b.stampMaterial = -1;
        }

        correctButtonsLeft1 = new float[] { 0, 0, 0, 0, 0,
                                            0, 0, 0, 1, 0,
                                            0, 0, 1, 0, 0,
                                            0, 1, 0, 1, 0,
                                            0, 0, 0, 0, 0};

        corrLeftBridge1 =     new float[] { 0, 0, 1, 0, 0,
                                            0, 0, 1, 0, 0,
                                            0, 1, 1, 1, 0,
                                            0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0};

        corrLeftBridge2 =     new float[] { 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0,
                                            0, 1, 1, 1, 0,
                                            0, 0, 1, 0, 0,
                                            0, 0, 1, 0, 0};

        corrLeftBridge3 =     new float[] { 0, 0, 0, 0, 0,
                                            0, 0, 1, 0, 0,
                                            0, 0, 1, 1, 1,
                                            0, 0, 1, 0, 0,
                                            0, 0, 0, 0, 0};


        corrRightBridge1 =    new float[] { 0, 0, 1, 1, 0,
                                            0, 0, 0, 1, 0,
                                            0, 0, 1, 1, 0,
                                            0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0};

        corrRightBridge2 =    new float[] { 0, 0, 0, 0, 0,
                                            0, 0, 0, 0, 0,
                                            0, 1, 1, 0, 0,
                                            0, 1, 0, 0, 0,
                                            0, 1, 1, 0, 0};


        firstRotators = new Element[] { L1, L2, L3, L4, L5, L6, L7, L8 };
        foreach (Element r in firstRotators)
        {
            Level.SetWrapMode(r, WrapMode.Loop);
        }

        foreach (Element r in firstRotators)
        {
            int rand = Random.Range(1, 6);
            Level.SetToHotspot(r, hotspot6, rand);
        }

        secondRotators = new Element[] { R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, R11, R12, R13, R14, R15, R16, R17, R18, R19, R20, R21, R22, R23, R24 };
        foreach (Element r in secondRotators)
        {
            Level.SetWrapMode(r, WrapMode.Loop);
        }

        foreach (Element r in secondRotators)
        {
            int rand = Random.Range(1, 6);
            Level.SetToHotspot(r, hotspot6, rand);
        }


        //RotLeft.wrapMode = WrapMode.Loop;
        RotLeft.GetComponent<Animation>().enabled = false;
        RotRight.GetComponent<Animation>().enabled = false;


        camMain = Camera.main;

    }

    // Update is called once per frame

    void Update()
    {
        if (!EditorApplication.isPlaying) return;

        RotLeft.transform.Rotate(Vector3.up);
        RotRight.transform.Rotate(Vector3.up);

        if (Time.frameCount % 3 == 0)
        {
         
            if (!EditorApplication.isPlaying) return;

            if (!camMain.enabled)
            {
                player.GetComponent<Movement>().enabled = false;
            }
            else
                player.GetComponent<Movement>().enabled = true;


            //HintL
            if (player.interact == HintLArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, HintLCam.transform);
            }

            if (HintLCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(HintLCam.transform, camMain.transform);
            }

            //HintR
            if (player.interact == HintRArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, HintRCam.transform);
            }

            if (HintRCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(HintRCam.transform, camMain.transform);
            }

            //Buttons
            if (player.interact == ButtonsArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, ButtonsCam.transform);
            }

            if (ButtonsCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(ButtonsCam.transform, camMain.transform);
            }

            //puzzleLeftRot
            if (player.interact == LeftRotArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, LeftRotCam.transform);
            }

            if (LeftRotCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(LeftRotCam.transform, camMain.transform);
            }

            //puzzleLeftRot
            if (player.interact == RightRotArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, RightRotCam.transform);
            }

            if (RightRotCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(RightRotCam.transform, camMain.transform);
            }


            foreach (Element r in firstRotators)
            {
                if (!r.isInteract && !isPressed)
                    Level.MoveToHotspot(r, hotspot6, Level.GetCurrentHotspot(r, hotspot6));
            }

            foreach (Element r in secondRotators)
            {
                if (!r.isInteract && !isPressed)
                    Level.MoveToHotspot(r, hotspot6, Level.GetCurrentHotspot(r, hotspot6));
            }



            if (player.interact == Restart)
            {
                StartCoroutine(NextLevel(false));
            }



            if (player.interact == portal)
            {
                StartCoroutine(NextLevel());
            }



            bool firstPuzzle = true;
            bool firstPuzzle2 = true;
            bool firstPuzzle3 = true;
            for (int i = 0; i < corrLeftBridge1.Length; i++)
            {
                if (buttons[i].animValue != corrLeftBridge1[i]) firstPuzzle = false;
            }
            for (int i = 0; i < corrLeftBridge2.Length; i++)
            {
                if (buttons[i].animValue != corrLeftBridge2[i]) firstPuzzle2 = false;
            }
            for (int i = 0; i < corrLeftBridge3.Length; i++)
            {
                if (buttons[i].animValue != corrLeftBridge3[i]) firstPuzzle3 = false;
            }
            if (firstPuzzle || firstPuzzle2 || firstPuzzle3)
            {
                if (Level.Stamp(Bridge, .5f))
                {
                    Level.Stamp(LeftHolder);
                    Level.Stamp(RightHolder);

                    Level.PushCamera(ButtonsCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }
            }

            bool secondPuzzle = true;
            bool secondPuzzle2 = true;
            for (int i = 0; i < corrRightBridge1.Length; i++)
            {
                if (buttons[i].animValue != corrRightBridge1[i]) secondPuzzle = false;
            }
            
            for (int i = 0; i < corrRightBridge2.Length; i++)
            {
                if (buttons[i].animValue != corrRightBridge2[i]) secondPuzzle2 = false;
            }
            if (secondPuzzle || secondPuzzle2)
            {
                if (Level.Stamp(Bridge2, .5f))
                {
                    Level.Stamp(LeftHolder2);
                    Level.Stamp(RightHolder2);

                    Level.PushCamera(ButtonsCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }
            }

            // Debug.Log(" " + Level.GetCurrentHotspot(Final1, hotspot12) +  " "  + Level.GetCurrentHotspot(Final2, hotspot12) + "  " + Level.GetCurrentHotspot(Final3, hotspot12));

            bool firstRotTrue = true;
            foreach (Element r in firstRotators)
            {
                if (Level.GetCurrentHotspot(r, hotspot6) != 0)
                    firstRotTrue = false;
            }

            if (firstRotTrue)
            {
                Debug.Log("prvi");
                if (Level.Stamp(FirstUp, .5f))
                {
                    Level.PushCamera(LeftRotCam.transform, camMain.transform);
                }
            }

            bool secondRotTrue = true;
            foreach (Element r in secondRotators)
            {
                if (Level.GetCurrentHotspot(r, hotspot6) != 0)
                    secondRotTrue = false;
            }

            if (secondRotTrue)
            {
                Debug.Log("Drugi");
                if (Level.Stamp(SecondUp, .5f))
                {
                    Level.PushCamera(RightRotCam.transform, camMain.transform);
                }
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


            foreach (Element r in firstRotators)
            {
                if (r.isInteract && !isPressed)
                {
                    
                    int val = Level.GetCurrentHotspot(r, hotspot6);
                    if (++val >= hotspot6.spots) val = 0;
                    StartCoroutine(MoveRotators());
                    Level.SetToHotspot(r, hotspot6, val);
                }
            }

            foreach (Element r in secondRotators)
            {
                if (r.isInteract && !isPressed)
                {

                    int val = Level.GetCurrentHotspot(r, hotspot6);
                    if (++val >= hotspot6.spots) val = 0;
                    StartCoroutine(MoveRotators());
                    Level.SetToHotspot(r, hotspot6, val);
                }
            }
        }

            
        

    }
    public bool isPressed = false;
    public IEnumerator MoveRotators()
    {
        isPressed = true;
        yield return new WaitForSeconds(.25f);
        isPressed = false;
    }


    public IEnumerator NextLevel(bool next = true)
    {
        ImageFade fade = GameObject.FindObjectOfType<ImageFade>();
        fade.FadeImage(false);
        if (next)
        { 
            yield return null;
            SceneManager.LoadScene("Level26");
        }
        else
        {
            yield return null;
            SceneManager.LoadScene("Level25");
        }
    }
}
