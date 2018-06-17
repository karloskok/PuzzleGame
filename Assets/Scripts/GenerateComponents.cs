using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateComponents : MonoBehaviour {

    //strings collisions
    string mesh = "MeshCollider";
    string box = "BoxCollider";
    string capsule = "CapsuleCollider";
    string area = "area";
    string boxes = "moveable";
    string trigger = "trigger";


    void Awake()
    {
        //  if (EditorApplication.isPlayingOrWillChangePlaymode) return;
        //    Debug.Log("start");

        ////
        /*
                    MeshCollider ->  add MeshCollider to object
                    BoxCollider ->   add BoxCollider to object
                    CapsuleCollider -> add CapsuleCollider to object
                    MeshCollider ->  add meshCollider to object

                    area -> disable meshRender
                    moveable -> add  RigidBody to object
                    trigger -> set BoxCollide to Trigger
                    
        */
        ////

        if (name.Contains(mesh) && !gameObject.GetComponent<MeshCollider>())
        {
            gameObject.AddComponent<MeshCollider>();

        }
         if (name.Contains(box) && !gameObject.GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>();
        }
         if (name.Contains(capsule) && !gameObject.GetComponent<CapsuleCollider>())
        {
            gameObject.AddComponent<CapsuleCollider>();
        }
         if (name.Contains(area) && gameObject.GetComponent<MeshRenderer>())
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.layer =  10;
        }
         if (name.Contains(trigger))
        {
            if(gameObject.GetComponent<BoxCollider>())
                gameObject.GetComponent<BoxCollider>().isTrigger = true;

            if (gameObject.GetComponent<MeshCollider>())
            {
                gameObject.GetComponent<MeshCollider>().convex = true;
                gameObject.GetComponent<MeshCollider>().isTrigger = true;

            }

        }
         if (name.Contains(boxes))
        {
            if (!gameObject.GetComponent<Rigidbody>())
                gameObject.AddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            if(gameObject.GetComponent<Animation>())
                gameObject.GetComponent<Animation>().enabled = false;
        }


        if (gameObject.GetComponent<MeshRenderer>())
        {
            if(name.Contains("Laser"))
                gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Color-PaletteLaser") as Material;
            else if (name.Contains("portal"))
                gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Color-PalettePortal") as Material;
            else
                gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Color-Palette") as Material;
        }

        if (gameObject.GetComponent<Animation>() && gameObject.name.Contains("Empty"))
            gameObject.GetComponent<Animation>().enabled=false;

        /*
                if (name.Contains("Start"))
                {
                    GameObject.FindWithTag("Player").transform.position = gameObject.transform.position;
                    if (gameObject.GetComponent<MeshRenderer>())
                        gameObject.GetComponent<MeshRenderer>().enabled = false;

                }

                if (name.Contains("CM"))
                {
                    if (gameObject.GetComponent<BoxCollider>())
                        gameObject.GetComponent<BoxCollider>().isTrigger = true;

                    gameObject.tag = "CM";
                    if (!gameObject.GetComponent<ChangeMaterial>())
                        gameObject.AddComponent<ChangeMaterial>();

                    if (name.Contains("ice")) gameObject.GetComponent<ChangeMaterial>().name = "ice";
                    else if (name.Contains("stone")) gameObject.GetComponent<ChangeMaterial>().name = "stone";
                    else if (name.Contains("lava")) gameObject.GetComponent<ChangeMaterial>().name = "lava";
                    else if (name.Contains("leafs")) gameObject.GetComponent<ChangeMaterial>().name = "leafs";

                    string n = gameObject.GetComponent<ChangeMaterial>().name;
                    gameObject.GetComponent<MeshRenderer>().material = Resources.Load(n) as Material;

                    //if(gameObject.GetComponent<MeshRenderer>())           
                    // gameObject.GetComponent<MeshRenderer>().material=null;

                }



                if (name.Contains("Enemy"))
                {
                    gameObject.tag = "Enemy";
                }



                if (name.Contains("RestartLevel"))
                {
                    if (!gameObject.GetComponent<RestartLevel>())
                    {
                        gameObject.AddComponent<RestartLevel>();
                    }
                    if (gameObject.GetComponent<BoxCollider>())
                        gameObject.GetComponent<BoxCollider>().isTrigger = true;

                    if (gameObject.GetComponent<MeshRenderer>())
                        gameObject.GetComponent<MeshRenderer>().enabled = false;
                    //gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Color-Water") as Material;       
                }



                if (name.Contains("Finish"))
                {
                    if (gameObject.GetComponent<BoxCollider>())
                        gameObject.GetComponent<BoxCollider>().isTrigger = true;
                    if (gameObject.GetComponent<MeshRenderer>())
                        gameObject.GetComponent<MeshRenderer>().enabled = false;

                    if (!gameObject.GetComponent<FinishLevel>())
                        gameObject.AddComponent<FinishLevel>();
                }

                if (name.Contains("LevelStar"))
                {
                    gameObject.tag = "Star";
                    gameObject.isStatic = false;
                    if (!gameObject.GetComponent<LevelStar>())
                        gameObject.AddComponent<LevelStar>();
                }

                if (name.Contains("Anim"))
                {
                    gameObject.tag = "Anim";
                    gameObject.isStatic = false;
                    //if (!gameObject.GetComponent<LevelStar>())
                    //    gameObject.AddComponent<LevelStar>();
                }

                if (name.Contains("Kutija"))
                {
                    //gameObject.tag = "Anim";
                    gameObject.isStatic = false;
                    if (!gameObject.GetComponent<Rigidbody>())
                    {
                        gameObject.AddComponent<Rigidbody>();
                        gameObject.GetComponent<Rigidbody>().mass = 0.1f;
                    }
                }
                */
        int i = name.IndexOf("_");

        if (i > 0)
        {
            name = name.Substring(0, i);
            gameObject.name = name;
        }

        //add materials


        //Debug.Log(name);
    }
}
