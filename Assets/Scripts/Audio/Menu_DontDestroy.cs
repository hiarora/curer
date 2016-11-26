using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class Menu_DontDestroy : MonoBehaviour {

	// Use this for initialization
	private bool wasLoaded = false;
	void OnLevelWasLoaded(int level) {
        if (level == 0 && wasLoaded) {
			Destroy(gameObject);
		}
        wasLoaded = true;
    }
	void Awake () {
		DontDestroyOnLoad(gameObject);		
	}
}
