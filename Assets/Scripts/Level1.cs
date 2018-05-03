using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Level1 : Level1Base
{

    PlayerInteract player;
    // Use this for initialization
    void Start()
    {
        if (!EditorApplication.isPlaying) return;
            Debug.Log("Playing");

        player = PlayerInteract.instance;

    }

    int frame = 3;
    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying) return;
        if (!player) return;



        if (player.interact == leverTrigger && Input.GetKeyDown(KeyCode.E))
        {
            lever.Stamp(4);
        }
        if (lever.WasStamped())
        {
            bridge.Stamp(2);
        }

        if (Press.interact == boxDoor)
        {
            //Debug.Log(true);
            door.Stamp();
            //door.MoveTowards(1, 0);
        }
    }

}
