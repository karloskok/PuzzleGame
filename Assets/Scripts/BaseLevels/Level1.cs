using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Level1 : Level1Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion

    Hotspots hotspot4;
    Hotspots hotspot5;


    float[] correctButtons;

    Element[] levers;
    Element[] buttons;

    Element[] rotators1, rotators2, rotators3, rotators4;


    // Use this for initialization
    void Start () {
       // if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        camMain = Camera.main;
        newCamPosition = camMain.transform;

        hotspot4 = new Hotspots(4);
        hotspot5 = new Hotspots(5);


        levers = new Element[] { L1, L2, L3, L4};

        foreach (Element l in levers)
        {
            l.elementMove = Element.ElementMove.y;
        }

        buttons = new Element[] { B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, B16, B17, B18, B19, B20, B21, B22, B23, B24, B25 };


        correctButtons = new float[] {  1, 0, 0, 0, 1,
                                        0, 1, 1, 1, 0,
                                        0, 0, 0, 0, 0,
                                        0, 1, 1, 1, 0,
                                        1, 0, 0, 0, 1};

        rotators1 = new Element[] { R11, R12, R13 };
        rotators2 = new Element[] { R21, R22, R23 };
        rotators3 = new Element[] { R31, R32, R33 };
        rotators4 = new Element[] { R41, R42, R43 };


    }

    // Update is called once per frame
    void Update()
    {
       // if (!EditorApplication.isPlaying) return;




        if (player.interact == firstLeverArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camLevers.transform);
        }
        if (camLevers.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camLevers.transform, camMain.transform);

        }

        if (!camMain.enabled)
        {
            player.GetComponent<Movement>().enabled = false;
        }
        else
            player.GetComponent<Movement>().enabled = true;


        foreach (Element l in levers)
        {
            if (!l.isInteract)
                Level.MoveToHotspot(l, hotspot4, Level.GetCurrentHotspot(l, hotspot4));

        }

        if (Level.GetCurrentHotspot(L1, hotspot4) == 3
            && Level.GetCurrentHotspot(L2, hotspot4) == 0
            && Level.GetCurrentHotspot(L3, hotspot4) == 2
            && Level.GetCurrentHotspot(L4, hotspot4) == 1)
        {

            if (Level.Stamp(BridgeStart, .5f))
                Level.PushCamera(camLevers.transform, camMain.transform);

        }



        if (Input.GetMouseButton(0))
        {
            foreach (Element l in levers)
            {
                if (l.isInteract)
                    Level.MoveTowards(l, l.animValue - l.angleFromStart, 2);
            }

            ///Level.SetAnimValue(elem, elem.animValue + elem.angleFromStart);
            //if (L1.isInteract)
            //    Level.MoveTowards(L1, L1.animValue - L1.angleFromStart, 2);
        }

        if (player.interact == BrokenLeverArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.Stamp(LeverBroken);

        }
        if (LeverBroken.wasStamped)
        {
            Level.Stamp(BridgeBroken);
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

        if (player.interact == ButtonsArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camButtons.transform);
        }
        if (camButtons.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camButtons.transform, camMain.transform);

        }

        int nmb = 0;
        for(int i =0; i< correctButtons.Length; i++)
        {
            if (buttons[i].animValue == correctButtons[i]) nmb++;
        }
        if (nmb == 25)
        {
            if(Level.Stamp(BridgeButtons))
                Level.PushCamera(camButtons.transform, camMain.transform);
        }

 
        if (player.interact == LiftLeverArea && Input.GetKeyDown(KeyCode.E))
        {
            Level.Stamp(Lift1, .2f);
        }

        ////rotators01
        if (player.interact == R1Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camR1.transform);
        }
        if (camR1.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camR1.transform, camMain.transform);

        }

        foreach(Element r in rotators1)
        {
            if (!r.isInteract)
                Level.MoveToHotspot(r, hotspot5, Level.GetCurrentHotspot(r, hotspot5));
        }

        if (Input.GetMouseButton(0))
        {
            foreach (Element r in rotators1)
            {
                if (r.isInteract)
                    Level.MoveTowards(r, r.animValue + r.angleFromStart, 1);
            }
        }
        ////rotators01

        ////rotators02
        if (player.interact == R2Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camR2.transform);
        }
        if (camR2.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camR2.transform, camMain.transform);

        }

        foreach (Element r in rotators2)
        {
            if (!r.isInteract)
                Level.MoveToHotspot(r, hotspot5, Level.GetCurrentHotspot(r, hotspot5));
        }

        if (Input.GetMouseButton(0))
        {
            foreach (Element r in rotators2)
            {
                if (r.isInteract)
                    Level.MoveTowards(r, r.animValue + r.angleFromStart, 1);
            }
        }
        ////rotators02

        ////rotators03
        if (player.interact == R3Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camR3.transform);
        }
        if (camR3.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camR3.transform, camMain.transform);

        }

        foreach (Element r in rotators3)
        {
            if (!r.isInteract)
                Level.MoveToHotspot(r, hotspot5, Level.GetCurrentHotspot(r, hotspot5));
        }

        if (Input.GetMouseButton(0))
        {
            foreach (Element r in rotators3)
            {
                if (r.isInteract)
                    Level.MoveTowards(r, r.animValue + r.angleFromStart, 1);
            }
        }
        ////rotators03

        ////rotators04
        if (player.interact == R4Area && Input.GetKeyDown(KeyCode.E))
        {
            Level.PushCamera(camMain.transform, camR4.transform);
        }
        if (camR4.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
        {
            Level.PushCamera(camR4.transform, camMain.transform);

        }

        foreach (Element r in rotators4)
        {
            if (!r.isInteract)
                Level.MoveToHotspot(r, hotspot5, Level.GetCurrentHotspot(r, hotspot5));
        }

        if (Input.GetMouseButton(0))
        {
            foreach (Element r in rotators4)
            {
                if (r.isInteract)
                    Level.MoveTowards(r, r.animValue + r.angleFromStart, 1);
            }
        }
        ////rotators04

        Level.Stamp(LiftUp);

    }
}
