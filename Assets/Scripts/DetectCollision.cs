using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    public GameObject uiScreen;
    public TextMeshProUGUI textObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "XR Origin")
        {
            uiScreen.SetActive(true);
            if (gameObject.name == "Goal")
            {
                // reached the goal point
                textObject.text = "You Win";
            }
            else
            {
                // hit the obstacle
                textObject.text = "You Lose";
            }


        }
        // Debug.Log("trigger World");
        print(other.gameObject.name);
        // throw new NotImplementedException();
    }
    
    
}
