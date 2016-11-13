using UnityEngine;
using System.Collections;

public class Menu_DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}
