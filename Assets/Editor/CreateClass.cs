using UnityEditor;
using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
public class CreateClass
{

    /// <summary>
    /// generate class for each level -- impotr models in fbx format and generate class, then attach it to base level object
    /// </summary>

    [MenuItem("DreamWorld/Create/Add C# Class LevelBase")]
    public static void Create(GameObject selected)//remove argument
    {
       // GameObject selected = Selection.activeObject as GameObject;
        Debug.Log(selected.name);


        if (selected == null || selected.name.Length <= 0 )
         {
            
            Debug.Log("Selected object not Valid");
            return;
        }

        // remove whitespace and minus
        string name = selected.name.Replace(" ", "_");
        name = name.Replace("-", "_");
        name=name + "Base";

        //delete old script
        //FileUtil.("Assets/Scripts/BaseLevels/" + name + ".cs");
        File.WriteAllText("Assets/Scripts/BaseLevels/" + name + ".cs", "");


        string copyPath = "Assets/Scripts/BaseLevels/" + name + ".cs";
        Debug.Log("Creating Classfile: " + copyPath);
        //if (File.Exists(copyPath) == false)
        { // do not overwrite
            using (StreamWriter outfile =
                new StreamWriter(copyPath))
            {
                outfile.WriteLine("using UnityEngine;");
                outfile.WriteLine("using System.Collections;");
                outfile.WriteLine("");
                outfile.WriteLine("[ExecuteInEditMode]");
                outfile.WriteLine("public class " + name + " : MonoBehaviour \n{");
                outfile.WriteLine(" ");
                outfile.WriteLine("\tint _index = 0; ");
                outfile.WriteLine(" ");

                //_elements = selected.GetComponentsInChildren<Transform>();
                // foreach
                Transform[] _elements = selected.GetComponentsInChildren<Transform>();
                string element_name;
                for(int i=1; i<_elements.Length; i++)//  Transform e in _elements)
                {
                    //
                    element_name = _elements[i].name;
                    int p = element_name.IndexOf("_");

                    if (p > 0)
                    {
                        element_name = element_name.Substring(0, p);
                    }
                    //
                    outfile.WriteLine("\tprotected Element " + element_name + ";");
                }

                

                outfile.WriteLine(" ");


                outfile.WriteLine("\tvoid Awake () \n\t{");
                outfile.WriteLine(" ");

                outfile.WriteLine("\t\tTransform[] _elements = GetComponentsInChildren<Transform>(); ");


                outfile.WriteLine("\t\tfor (int i = 1; i < _elements.Length; i++)\n\t\t{");

                outfile.WriteLine("\t \t \tif (!_elements[i].gameObject.GetComponent<Element>())");
                outfile.WriteLine("\t \t  \t\t_elements[i].gameObject.AddComponent<Element>();");
                outfile.WriteLine("\t \t  \t_elements[i].gameObject.GetComponent<Element>()._name = _elements[i].gameObject.name;");
                outfile.WriteLine("\t  \t\t_elements[i].gameObject.GetComponent<Element>()._index = ++_index;");
                outfile.WriteLine(" ");
                outfile.WriteLine(" ");
                outfile.WriteLine("\t\t\tif (!_elements[i].gameObject.GetComponent<GenerateComponents>())");
                outfile.WriteLine("\t\t\t_elements[i].gameObject.AddComponent<GenerateComponents>();");
                outfile.WriteLine(" ");
                outfile.WriteLine("\t\t}");
                outfile.WriteLine(" ");
                outfile.WriteLine(" ");
                /*
                                ///
                                outfile.WriteLine("foreach (var e in _elements) " +
                                    "\n  {" +
                                    " \n  " +
                                    "if (!e.gameObject.GetComponent<Element>())\n " +
                                    " e.gameObject.AddComponent<Element>();\n " +
                                    "e.gameObject.GetComponent<Element>().name = e.gameObject.name; \n" +
                                    "e.gameObject.GetComponent<Element>().index = ++_index;" +
                                    "\n }\n");


                               */


                for (int i = 1; i < _elements.Length; i++)//  Transform e in _elements)
                {
                    //
                    element_name = _elements[i].name;
                    int p = element_name.IndexOf("_");

                    if (p > 0)
                    {
                        element_name = element_name.Substring(0, p);
                    }
                    //

                    /// string n = //name.Replace("Base", "");
                    /// outfile.WriteLine("\t\t" + element_name + " = " + "GameObject.Find(" + '"' + n + "/" + element_name + '"' + ").GetComponent<Element>();");

                    string n =  GetGameObjectPath(_elements[i].gameObject);
                    int v = n.IndexOf("_");

                    if (v > 0)
                    {
                        n = n.Substring(0, v);
                    }
                    outfile.WriteLine("\t\t" + element_name + " = " + "GameObject.Find(" + '"' + n + '"' + ").GetComponent<Element>();");
                    ////Debug.LogError(n);
                    // Cube = GameObject.Find("/cube/Cube").GetComponent<Elem>();
                }

                outfile.WriteLine("\t\tDestroyImmediate(GetComponent<Element>());");
                outfile.WriteLine("\t\tDestroyImmediate(GetComponent<Animation>());");

                outfile.WriteLine(" ");
                outfile.WriteLine("\t}");
                outfile.WriteLine(" ");

/*
                outfile.WriteLine(" // Use this for initialization");
                outfile.WriteLine(" void Start () {");
                outfile.WriteLine(" ");
                outfile.WriteLine(" }");
                //outfile.WriteLine(" ");
                //outfile.WriteLine(" ");
                //outfile.WriteLine(" // Update is called once per frame");
                //outfile.WriteLine(" void Update () {");
                //outfile.WriteLine(" ");
                //outfile.WriteLine(" }");
                */
                outfile.WriteLine("}");
            }//File written
        }
        AssetDatabase.Refresh();
        //selected.gameObject.AddComponent<>();
        //selected.gameObject.AddComponent<>();
    }

    public static string GetGameObjectPath(GameObject obj)
    {
        string path = "/" + obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        return path;
    }
}