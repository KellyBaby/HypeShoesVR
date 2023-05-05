using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movementMultiplier = 1f;
    public GameObject origin;
    public GameObject userCamera;
    
    public float yAngleRotation = 0.01f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var newPosition = origin.transform.position;
        var headsetTransform = userCamera.transform;
        headsetTransform.position = new Vector3(headsetTransform.position.x,0,headsetTransform.position.z);
        // print(headsetTransform.position);
        newPosition += movementMultiplier * Time.deltaTime * headsetTransform.forward ;
        newPosition.y = origin.transform.position.y;
        origin.transform.position = newPosition; 
        // player.transform.Rotate(0f,yAngleRotation,0f);
        
        // var newPosition = player.transform.position;
        // newPosition.x += baseSpeed * movementMultiplier;
        //
        // player.transform.position = newPosition;
    }
}
