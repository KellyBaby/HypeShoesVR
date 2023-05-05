using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    // The maximum speed at which the asteroid can rotate
    public float maxRotationSpeed = 20f;

    // The current rotation speed of the asteroid around the x-axis
    private float xRotationSpeed;

    // The current rotation speed of the asteroid around the y-axis
    private float yRotationSpeed;

    // The current rotation speed of the asteroid around the z-axis
    private float zRotationSpeed;

    void Start()
    {
        // Set random rotation speeds for the asteroid around each axis
        xRotationSpeed = Random.Range(0f, maxRotationSpeed);
        yRotationSpeed = Random.Range(0f, maxRotationSpeed);
        zRotationSpeed = Random.Range(0f, maxRotationSpeed);
    }

    void Update()
    {
        // Rotate the asteroid around all three axes
        transform.Rotate(new Vector3(xRotationSpeed, yRotationSpeed, zRotationSpeed) * Time.deltaTime, Space.World);
    }
}
