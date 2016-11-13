using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CubeTransparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//this.gameObject.addComponent("Renderer").material = new Material(Shader.Find("Transparent/Diffuse"));
		Renderer r = this.gameObject.GetComponent<MeshRenderer>();
		Debug.Log(Shader.Find("Transparent/Diffuse"));
		r.material = new Material(Shader.Find("Transparent/Diffuse"));
        r.material.color = new Color(1, 1, 1, 0.4f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
