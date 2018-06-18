using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;

public class Level21 : Level21Base {

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

        if (PlayerPrefs.GetInt("LastLevel", 0) < 1) PlayerPrefs.SetInt("LastLevel", 0);
        // if (PlayerPrefs.GetInt("Shadow") == 1) InGameMenuController.sunce.shadowStrength = 1;


        player = PlayerInteract.instance;

        Hover.elementMove = Element.ElementMove.y;
        LeftHandle.elementMove = Element.ElementMove.y;
        RightHandle.elementMove = Element.ElementMove.y;

        camMain = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        //if (!EditorApplication.isPlaying) return;

        



            if (!camMain.enabled)
            {
                player.GetComponent<Movement>().enabled = false;
            }
            else
                player.GetComponent<Movement>().enabled = true;


            //startlit
            if (player.interact == HandleArea && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, StarttCam.transform);
            }

            if (StarttCam.GetComponent<Camera>().enabled && !player.GetComponent<Movement>().enabled && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(StarttCam.transform, camMain.transform);
            }



            //leftarea
            if (player.interact == LeftArea && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, leftCam.transform);
            }

            if (leftCam.GetComponent<Camera>().enabled && !player.GetComponent<Movement>().enabled && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(leftCam.transform, camMain.transform);
            }

            //rightarea
            if (player.interact == RightArea && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, RightCam.transform);
            }

            if (RightCam.GetComponent<Camera>().enabled && !player.GetComponent<Movement>().enabled && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(RightCam.transform, camMain.transform);
            }
        if (Time.frameCount % 3 == 0)
        {

            if (Hover.animValue >= .9f)
            {
                if (Level.Stamp(Hover)) ;
                //    Level.PushCamera(StarttCam.transform, camMain.transform);
                //Level.Stamp(LeftHolder, .5f);
            }
            if (HandleInside.animValue >= .85f)
            {
                if (Level.Stamp(HandleInside))
                {
                    Level.PushCamera(StarttCam.transform, camMain.transform);
                    Level.Stamp(BridgeStart, .2f);
                    if (MusicPlayer.instance.efxSource.isPlaying)
                        MusicPlayer.instance.PlaySingle("bridge");
                }
                //    
            }

            if (LeftHandle.animValue >= .9f)
            {
                if (Level.Stamp(LeftHandle))
                    Level.PushCamera(leftCam.transform, camMain.transform);
                Level.Stamp(LeftHolder, .5f);

                if (RightHandle.wasStamped)
                {
                    if (Level.Stamp(Bridge, .8f)) ;
                }

            }
            if (RightHandle.animValue >= .9f)
            {
                if (Level.Stamp(RightHandle))
                    Level.PushCamera(RightCam.transform, camMain.transform);
                Level.Stamp(RightHolder, .5f);

                if (LeftHandle.wasStamped)
                {
                    if (Level.Stamp(Bridge, .8f)) ;
                }

            }


            if (player.interact == Restart)
            {
                StartCoroutine(NextLevel(false));
            }

            //if (Lever.wasStamped)
            //{
            //    if(Level.Stamp(Bridge, .2f))
            //        if(!MusicPlayer.instance.efxSource.isPlaying)
            //            MusicPlayer.instance.PlaySingle("bridge");
            //}

            if (player.interact == portal)
            {
                StartCoroutine(NextLevel());
            }


        }


        if (Input.GetMouseButton(0))
        {

            if (Hover.isInteract || HoverHandle.isInteract)
                Level.MoveTowards(Hover, Hover.animValue + Hover.angleFromStart, 1f);

            if (HandleInside.isInteract)
            {
                Level.MoveTowards(HandleInside, HandleInside.animValue + HandleInside.angleFromStart, 1f);
                if (!MusicPlayer.instance.efxSource.isPlaying)
                    MusicPlayer.instance.PlaySingle("handle");
            }
            if (LeftHandle.isInteract)
                Level.MoveTowards(LeftHandle, LeftHandle.animValue + LeftHandle.angleFromStart, 1f);

            if (RightHandle.isInteract)
                Level.MoveTowards(RightHandle, RightHandle.animValue + RightHandle.angleFromStart, 1f);

        }
        
    }

    public IEnumerator NextLevel(bool next = true)
    {
        ImageFade fade = GameObject.FindObjectOfType<ImageFade>();
        fade.FadeImage(false);
        if (next)
        { 
            yield return null;
            SceneManager.LoadScene("Level22");
        }
        else
        {
            yield return null;
            SceneManager.LoadScene("Level21");
        }
    }
}
