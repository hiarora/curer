using UnityEngine;
using System;
using System.IO;

public class OpaqueSpiderWalker : MonoBehaviour
{
    Vector3 originalPosition;
	Rigidbody rigidbody = null;
	public Camera main;
	Renderer r = null;
    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
		main = Camera.main;
		r = this.gameObject.GetComponent<MeshRenderer>();
		Color temp = r.material.color;
		temp.a = 0;
		r.material.color = temp;
		 // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			rigidbody.useGravity = false;
			rigidbody.AddForce((main.gameObject.transform.position - originalPosition) * 1f);
        }
    }

	void Update() {
		//rigidbody.velocity = main.gameObject.transform.position
		/*if(r.material.color.a < 1) {
			
		}
			(r.material.color.a) += 0.005f;*/
	}
}