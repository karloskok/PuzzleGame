using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;

class GenerateLevelScript : AssetPostprocessor
{

    void OnPreprocessModel()
    {

        if (assetPath.StartsWith("Assets/Levels") && assetImporter.name.Contains("Level"))
        {
            PreprocessLevels();
        }
    }

    private void PreprocessLevels()
    {
        ModelImporter importer = (ModelImporter)assetImporter;
        importer.animationType = ModelImporterAnimationType.Legacy;
        //CreateClass.Create();
       // Debug.Log(importer.);

    }


    void OnPostprocessModel(GameObject g)
    {
        //Debug.Log(g.name);
        CreateClass.Create(g);
        //string s = g.name + "Base";
       // Debug.Log(Assembly.Load(s));
        // Debug.Log(System.Type.GetType("UnityEngine." + s).Name);

        //Assembly. asem;

        //foreach (Type t in Assembly.Load("").)

        //{

        //    Debug.Log(t.FullName);

        //}

        // g.AddComponent(System.mo.GetType("/Assets/Scripts/BaseLevels/" + s));

    }

}
