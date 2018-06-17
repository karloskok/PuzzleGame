using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level24 : Level24Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion


    Element[] rotFirst, rotSecond, rotThird, FinalRot;
    Hotspots hotspot4, hotspot5, hotspot12;


    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        //Hover.elementMove = Element.ElementMove.y;
        //LeftHandle.elementMove = Element.ElementMove.y;
        //RightHandle.elementMove = Element.ElementMove.y;
        hotspot4 = new Hotspots(4);
        hotspot5 = new Hotspots(5);
        hotspot12 = new Hotspots(13);


        rotFirst = new Element[] { FR1, FR2, FR3, FR4 };
        foreach (Element b in rotFirst)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(FR1, hotspot5, 3);
        Level.SetToHotspot(FR2, hotspot5, 2);
        Level.SetToHotspot(FR3, hotspot5, 3);
        Level.SetToHotspot(FR4, hotspot5, 1);

        rotSecond = new Element[] { SR1, SR2, SR3, SR4 };
        foreach (Element b in rotSecond)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(SR1, hotspot5, 2);
        Level.SetToHotspot(SR2, hotspot5, 4);
        Level.SetToHotspot(SR3, hotspot5, 3);
        Level.SetToHotspot(SR4, hotspot5, 1);

        rotThird = new Element[] { TR1, TR2, TR3, TR4 };
        foreach (Element b in rotThird)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(TR1, hotspot5, 2);
        Level.SetToHotspot(TR2, hotspot5, 4);
        Level.SetToHotspot(TR3, hotspot5, 3);
        Level.SetToHotspot(TR4, hotspot5, 1);

        SecondArea.isActive = false;
        ThirdArea.isActive = false;
        FinalArea.isActive = false;
        portal.isActive = false;

        FinalRot = new Element[] { Final1, Final2, Final3 };
        foreach (Element b in FinalRot)
        {
            b.wrapMode = WrapMode.Loop;
        }
        Level.SetToHotspot(Final1, hotspot5, 5);
        Level.SetToHotspot(Final2, hotspot5, 1);
        Level.SetToHotspot(Final3, hotspot5, 2);


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
            if (player.interact == FirstArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, FirstCam.transform);
            }

            if (FirstCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(FirstCam.transform, camMain.transform);
            }

            //puzzle02
            if (player.interact == SecondArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, SecondCam.transform);
            }

            if (SecondCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(SecondCam.transform, camMain.transform);
            }

            //puzzle03
            if (player.interact == ThirdArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, ThirdCam.transform);
            }

            if (ThirdCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(ThirdCam.transform, camMain.transform);
            }

            //Finalrot
            if (player.interact == FinalArea && Input.GetKey(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, FinalCam.transform);
            }

            if (FinalCam.GetComponent<Camera>().enabled && Input.GetKey(KeyCode.Escape))
            {
                Level.PushCamera(FinalCam.transform, camMain.transform);
            }


            foreach (Element l in rotFirst)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot5, Level.GetCurrentHotspot(l, hotspot5));

            }
            for(int i = 0; i < 4; i++)
            {
                if(Level.GetCurrentHotspot(FR1, hotspot5) == i &&
                   Level.GetCurrentHotspot(FR2, hotspot5) == i &&
                   Level.GetCurrentHotspot(FR3, hotspot5) == i &&
                   Level.GetCurrentHotspot(FR4, hotspot5) == i &&
                   !FR1.isInteract && !FR2.isInteract && !FR3.isInteract && !FR4.isInteract)
                {
                   // Debug.Log("first");
                    if (Level.Stamp(SecondHover, .7f))
                    {
                        SecondArea.isActive = true;
                        SecondArea.gameObject.SetActive(true);
                        Level.PushCamera(FirstCam.transform, camMain.transform);
                    }
                }
            }

            foreach (Element l in rotSecond)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot5, Level.GetCurrentHotspot(l, hotspot5));

            }
            for (int i = 0; i < 4; i++)
            {
                if (Level.GetCurrentHotspot(SR1, hotspot5) == i &&
                   Level.GetCurrentHotspot(SR2, hotspot5) == i &&
                   Level.GetCurrentHotspot(SR3, hotspot5) == i &&
                   Level.GetCurrentHotspot(SR4, hotspot5) == i &&
                   !SR1.isInteract && !SR2.isInteract && !SR3.isInteract && !SR4.isInteract)
                {
                    //Debug.Log("second");
                    if (Level.Stamp(ThirdHover, .7f))
                    {
                        ThirdArea.isActive = true;
                        ThirdArea.gameObject.SetActive(true);
                        Level.PushCamera(SecondCam.transform, camMain.transform);
                    }
                }
            }

            foreach (Element l in rotThird)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot5, Level.GetCurrentHotspot(l, hotspot5));

            }
            for (int i = 0; i < 4; i++)
            {
                if (Level.GetCurrentHotspot(TR1, hotspot5) == i &&
                   Level.GetCurrentHotspot(TR2, hotspot5) == i &&
                   Level.GetCurrentHotspot(TR3, hotspot5) == i &&
                   Level.GetCurrentHotspot(TR4, hotspot5) == i &&
                   !TR1.isInteract && !TR2.isInteract && !TR3.isInteract && !TR4.isInteract)
                {
                    if (Level.Stamp(FinalHover, .7f))
                    {
                        //Debug.Log("third");
                        FinalArea.isActive = true;
                        FinalArea.gameObject.SetActive(true);
                        Level.PushCamera(ThirdCam.transform, camMain.transform);
                    }
                }
            }


            foreach (Element l in FinalRot)
            {
                if (!l.isInteract)
                    Level.MoveToHotspot(l, hotspot12, Level.GetCurrentHotspot(l, hotspot12));

            }


            if (Level.GetCurrentHotspot(Final1, hotspot12) == 2 &&
               Level.GetCurrentHotspot(Final2, hotspot12) == 8 &&
               Level.GetCurrentHotspot(Final3, hotspot12) == 4 &&
               !Final1.isInteract && !Final2.isInteract && !Final3.isInteract)
            {
               // Debug.Log("final");
                portal.isActive = true;
                portal.gameObject.SetActive(true);
                Level.PushCamera(FinalCam.transform, camMain.transform);
            }
            

            if (player.interact == Restart)
            {
                StartCoroutine(NextLevel(false));
            }



            if (player.interact == portal)
            {
                StartCoroutine(NextLevel());
            }



           // Debug.Log(" " + Level.GetCurrentHotspot(Final1, hotspot12) +  " "  + Level.GetCurrentHotspot(Final2, hotspot12) + "  " + Level.GetCurrentHotspot(Final3, hotspot12));

        }

        if (Input.GetMouseButton(0))
            {

            foreach (Element l in rotFirst)
            {
                if (l.isInteract)
                    Level.MoveTowards(l, l.angleFromStart < 0 ? l.animValue - l.angleFromStart : l.animValue, .8f);

            }

            foreach (Element l in rotSecond)
            {
                if (l.isInteract)
                    Level.MoveTowards(l, l.angleFromStart < 0 ? l.animValue - l.angleFromStart : l.animValue, .8f);

            }

            foreach (Element l in rotThird)
            {
                if (l.isInteract)
                    Level.MoveTowards(l, l.angleFromStart < 0 ? l.animValue - l.angleFromStart : l.animValue, .8f);

            }

            foreach (Element l in FinalRot)
            {
                if (l.isInteract)
                    Level.MoveTowards(l, l.angleFromStart < 0 ? l.animValue - l.angleFromStart : l.animValue, .45f);

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
            SceneManager.LoadScene("Level25");
        }
        else
        {
            yield return null;
            SceneManager.LoadScene("Level24");
        }
    }
}
