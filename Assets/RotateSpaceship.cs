using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpaceship : MonoBehaviour
{

    public GameObject playerObject;
    // Start is called before the first frame update
    void Start()
    {


    }

    private void FixedUpdate()
    {
        // Get the transform components of the game objects
        Transform sourceTransform = playerObject.transform;
        Transform targetTransform = gameObject.transform;

        // Get the current y rotation of the source object
        float yRotation = sourceTransform.rotation.eulerAngles.y;

        // Create a new quaternion with the y rotation value
        Quaternion newRotation = Quaternion.Euler(0f, yRotation, 0f);

        // Set the rotation of the target object to the new quaternion
        targetTransform.rotation = newRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
