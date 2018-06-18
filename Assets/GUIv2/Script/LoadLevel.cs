using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	// Use this for initialization
	public void LoadLevelAtIndex(string name) {

        SceneManager.LoadScene(name);

	}

}
