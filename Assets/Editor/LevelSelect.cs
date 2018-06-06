using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class LevelSelect  {




    [MenuItem("DreamWorld/Levels/Level1")]
    static void LoadLevel1Scene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Level1.unity");
    }

    [MenuItem("DreamWorld/Levels/Level2")]
    static void LoadLevel2Scene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Level2.unity");
    }

    [MenuItem("DreamWorld/Levels/Level3")]
    static void LoadLevel3Scene()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Level3.unity");
    }



}
