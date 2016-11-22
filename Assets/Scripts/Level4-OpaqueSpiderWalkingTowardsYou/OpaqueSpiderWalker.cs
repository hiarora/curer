using UnityEngine;
using System;
using System.IO;

public class OpaqueSpiderWalker : MonoBehaviour
{
    Vector3 originalPosition;
	Rigidbody rigidbody= null;
    bool hardStop = false;
    public Camera main;
    Vector3 previousCameraPosition;
    // Use this for initialization
    void Start()
    {
        // Grab the original local position of the sphere when the app starts.
        originalPosition = this.transform.localPosition;
		main = Camera.main;
        previousCameraPosition = main.gameObject.transform.position;
		 // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            rigidbody = this.gameObject.AddComponent<Rigidbody>();
        }
        rigidbody.isKinematic = false;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.useGravity = false;
        Vector3 v3 = main.gameObject.transform.position - originalPosition;
        v3.Normalize();
        rigidbody.AddForce(v3 * 20);
    }

	void Update() {
        originalPosition = this.transform.localPosition;
        main = Camera.main;

        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Stop"))
        {
            Stop();
        }

        //follow users if user position changes
        if (previousCameraPosition != main.gameObject.transform.position && hardStop == false)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            Vector3 v3 = main.gameObject.transform.position - originalPosition;
            v3.Normalize();
            rigidbody.AddForce(v3 * 20);
            previousCameraPosition = main.gameObject.transform.position;
        }

        //stops spider once it is in front of user
        var distance = Vector3.Distance(main.gameObject.transform.position, originalPosition);
        if (distance <= 3)
        {
            Stop();
        }

        //rotates to always face user
        var n = main.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.LookRotation(n);
    }
    
    public void Stop()
    {
        hardStop = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        this.GetComponent<Animator>().Play("Stop");
    }

    public void Move()
    {
        hardStop = false;
        originalPosition = this.transform.localPosition;
        main = Camera.main;
        Vector3 v3 = main.gameObject.transform.position - originalPosition;
        v3.Normalize();
        rigidbody.AddForce(v3 * 20);
        this.GetComponent<Animator>().Play("Walk");
    }

    public void OpacityUp()
    {
        Component[] renderers = this.gameObject.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer curRenderer in renderers)
        {
            Color color;
            foreach (Material material in curRenderer.materials)
            {
                color = material.color;
                color.a += 0.2f;
                if (color.a >= 1)
                {
                    color.a = 1;
                }
                material.color = color;
            }
        }
    }

    public void OpacityDown()
    {
        Component[] renderers = this.gameObject.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer curRenderer in renderers)
        {
            Color color;
            foreach (Material material in curRenderer.materials)
            {
                color = material.color;
                color.a -= 0.2f;
                if (color.a < 0.1f)
                {
                    color.a = 0.1f;
                }
                material.color = color;
            }
        }
    }

    public void Appear()
    {
        Component[] renderers = this.gameObject.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer curRenderer in renderers)
        {
            Color color;
            foreach (Material material in curRenderer.materials)
            {
                color = material.color;
                color.a = 1;
                material.color = color;
            }
        }
    }

    public void Disappear()
    {
        Component[] renderers = this.gameObject.GetComponentsInChildren(typeof(Renderer));
        foreach (Renderer curRenderer in renderers)
        {
            Color color;
            foreach (Material material in curRenderer.materials)
            {
                color = material.color;
                color.a = 0;
                material.color = color;
            }
        }
    }
}