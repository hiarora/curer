using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CubeTransparent : MonoBehaviour {
    //public Camera main;

	// Use this for initialization
	void Start () {
		//this.gameObject.addComponent("Renderer").material = new Material(Shader.Find("Transparent/Diffuse"));
		Renderer r = this.gameObject.GetComponent<MeshRenderer>();
		r.material.color = new Color(0, 0, 0, 0.4f);
		Debug.Log(r.material.color);

        this.transform.position = new Vector3(0, 4.0f, 1.11f);
        this.transform.localScale = new Vector3(4.0f, 2.5f, 4.0f);

        /*
        main = Camera.main;
        main.transform.position = new Vector3(0, 8, -10);
        main.transform.rotation = Quaternion.Euler(25, 0, 0);
        */
    }
}
