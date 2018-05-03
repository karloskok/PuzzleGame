using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Level3 : Level3Base
{

    PlayerInteract player;
    // Use this for initialization
    void Start()
    {
        if (!EditorApplication.isPlaying) return;
        Debug.Log("Playing");

        player = PlayerInteract.instance;


        bridgeLever.Stamp();

    }

    int frame = 3;
    // Update is called once per frame
    void Update()
    {
        if (!EditorApplication.isPlaying) return;
        if (!player) return;

        if (bridgeLever.WasStamped())
        {
            bridge.Stamp();
        }

    }

}
