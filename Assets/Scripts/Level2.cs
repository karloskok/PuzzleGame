using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Level2 : Level2Base
{

    PlayerInteract player;
    // Use this for initialization
    void Start()
    {
        if (!EditorApplication.isPlaying) return;
        Debug.Log("Playing");

        player = PlayerInteract.instance;
        Circle.gameObject.SetActive(false);
       // Circle.SetVisible(false);
        Circle.meshRenderer.material = Resources.Load("Color-PalettePortal") as Material;
        floor.meshCollider.enabled = false;

    }

    int frame = 3;
    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying) return;
        if (!player) return;

        if (bluePress.interact == blueCube)
        {
            greenUp.Stamp();
            greenPress.Stamp();
        }

        if (greenPress.interact == greenCube)
        {
            redUp.Stamp();
            redPress.Stamp();
        }

        if (redPress.interact == redCube)
        {
            portalUp.Stamp();
            Circle.visible = true;

        }

        if (portalUp.WasStamped())
        {
            Circle.gameObject.SetActive(true);

            // Circle.SetVisible(true);
            //Circle.meshRenderer.material = Resources.Load("/Color-PalettePortal") as Material;
        }
        if(player.interact == Circle)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }


    }

}
