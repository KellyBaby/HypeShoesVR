using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class btn_StartwithShoes : MonoBehaviour
{
    private XRController controller;
    void Start(){
        controller = GetComponent<XRController>();
    }
    public string sceneToSwitch="MainGame"; // Name of the scene to switch to when the button is clicked

    public void SwitchScene()
    {
        PlayerPrefs.SetString("ControlMode","Shoes");
        SceneManager.LoadScene(sceneToSwitch, LoadSceneMode.Single);
    }
    void Update(){
        if (Gamepad.current != null )
        {
            if (Gamepad.current.bButton.wasPressedThisFrame)
            {
                SwitchScene();
                Debug.Log("B button pressed on VR controller");
                // Handle B button press here
            }
        }
    }
}
