using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Level22 : Level22Base {

    PlayerInteract player;

    #region ForAllLevels
    public Camera camMain;
    Transform newCamPosition;
    Transform startCamPosition;
    /////PlayerInteract player;
    #endregion


    Element[] buttons, buttons2;
    float[] correctButtons1, correctButtons2;
   

    // Use this for initialization
    void Start () {
        if (!EditorApplication.isPlaying) return;


        player = PlayerInteract.instance;

        //Hover.elementMove = Element.ElementMove.y;
        //LeftHandle.elementMove = Element.ElementMove.y;
        //RightHandle.elementMove = Element.ElementMove.y;

        buttons = new Element[] { B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15, B16, B17, B18, B19, B20, B21, B22, B23, B24, B25 };
        correctButtons1 = new float[] { 0, 0, 0, 0, 0,
                                        0, 0, 0, 1, 0,
                                        0, 0, 1, 0, 0,
                                        0, 1, 0, 1, 0,
                                        0, 0, 0, 0, 0};
        buttons2 = new Element[] { C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25 };
        correctButtons2 = new float[] { 1, 0, 1, 0, 1,
                                        0, 1, 0, 1, 0,
                                        1, 0, 1, 0, 1,
                                        0, 1, 0, 1, 0,
                                        1, 0, 1, 0, 1};

        foreach (Element b in buttons)
        {
            b.stampMaterial = -1;
        }
        foreach (Element b in buttons2)
        {
            b.stampMaterial = -1;
        }

        camMain = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying) return;

        if (Time.frameCount % 3 == 0)
        {

            if (!camMain.enabled)
            {
                player.GetComponent<Movement>().enabled = false;
            }
            else
                player.GetComponent<Movement>().enabled = true;


            //puzzle01
            if (player.interact == Puzzle1Area && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, PuzzleCam.transform);
            }

            if (PuzzleCam.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
            {
                Level.PushCamera(PuzzleCam.transform, camMain.transform);
            }

            //hint01
            if (player.interact == Hint1Area && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, HintCam.transform);
            }

            if (HintCam.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
            {
                Level.PushCamera(HintCam.transform, camMain.transform);
            }

            //hint02
            if (player.interact == Hint2Area && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, Hint2Cam.transform);
            }

            if (Hint2Cam.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
            {
                Level.PushCamera(Hint2Cam.transform, camMain.transform);
            }

            //puzzle02
            if (player.interact == Puzzle2Area && Input.GetKeyDown(KeyCode.E))
            {
                Level.PushCamera(camMain.transform, Puzzle2Cam.transform);
            }

            if (Puzzle2Cam.GetComponent<Camera>().enabled && Input.GetKeyDown(KeyCode.Escape))
            {
                Level.PushCamera(Puzzle2Cam.transform, camMain.transform);
            }




            bool firstPuzzle = true;
            for (int i = 0; i < correctButtons1.Length; i++)
            {
                if (buttons[i].animValue != correctButtons1[i]) firstPuzzle = false;
            }
            if (firstPuzzle)
            {
                if (Level.Stamp(Gate01))
                {
                    Level.PushCamera(PuzzleCam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
                }
            }
            bool secondPuzzle = true;
            for (int i = 0; i < correctButtons2.Length; i++)
            {
                if (buttons2[i].animValue != correctButtons2[i]) secondPuzzle = false;
            }
            if (secondPuzzle)
            {
                if (Level.Stamp(Gate02))
                {
                    Level.PushCamera(Puzzle2Cam.transform, camMain.transform);
                    //if (!MusicPlayer.instance.efxSource.isPlaying)
                    //    MusicPlayer.instance.PlaySingle("bridge");
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

            foreach (Element b in buttons)
            {
                if (b.isInteract)
                {
                    Level.Stamp(b, b.animValue < .5f ? 1 : -1);
                }
            }

            foreach (Element b in buttons2)
            {
                if (b.isInteract)
                {
                    Level.Stamp(b, b.animValue < .5f ? 1 : -1);
                }
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
            SceneManager.LoadScene("Level23");
        }
        else
        {
            yield return null;
            SceneManager.LoadScene("Level22");
        }
    }
}
