using UnityEngine;
using System;
using System.IO;

public class Spider : MonoBehaviour
{
   /* Vector3 originalPosition;
	Rigidbody rigidbody = null;
	public Camera main;
    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
		main = Camera.main;
		 // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			rigidbody.useGravity = false;
			rigidbody.AddForce((main.gameObject.transform.position - originalPosition) * 1f);
        }
    }

    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
       
    }

    // Called by SpeechManager when the user says the "Reset world" command
    void OnReset()
    {
        // If the sphere has a Rigidbody component, remove it to disable physics.
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }

        // Put the sphere back into its original local position.
        this.transform.localPosition = originalPosition;
    }

    // Called by SpeechManager when the user says the "Drop sphere" command
    void OnDrop()
    {
        // Just do the same logic as a Select gesture.
        OnSelect();
    }
	
	void Update() {
		//rigidbody.velocity = main.gameObject.transform.position
	}*/
}