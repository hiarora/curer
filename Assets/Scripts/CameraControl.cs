using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(0.5f, 8, -10);
        this.transform.rotation = Quaternion.Euler(25, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
