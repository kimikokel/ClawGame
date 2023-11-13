using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody rigidBody;
    Vector3 customGravity; // Set your custom gravity here

    void Start()
    {
        customGravity = new Vector3(0,-500,0);

        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        // Set the custom gravity for this specific rigidbody
        rigidBody.useGravity = false; // Disable default gravity
    }

    void FixedUpdate()
    {
        // Apply custom gravity
        rigidBody.AddForce(customGravity, ForceMode.Acceleration);
    }
}
