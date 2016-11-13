using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class CubeTransparent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//this.gameObject.addComponent("Renderer").material = new Material(Shader.Find("Transparent/Diffuse"));
		Renderer r = this.gameObject.GetComponent<MeshRenderer>();
		r.material.color = new Color(1, 1, 1, 0.4f);
		Debug.Log(r.material.color);
    }
}
