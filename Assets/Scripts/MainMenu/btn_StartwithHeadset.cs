using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btn_StartwithHeadset : MonoBehaviour
{
    public string sceneToSwitch="MainGame"; // Name of the scene to switch to when the button is clicked

    public void SwitchScene()
    {
        PlayerPrefs.SetString("ControlMode","Headset");
        PlayerPrefs.SetString("debugText","HeadsetClicked");
        print("aaaaa");
        SceneManager.LoadScene(sceneToSwitch, LoadSceneMode.Single);
    }
    float time=0;
    void Update(){
        time+=1;
        if(time>2000){
            SwitchScene();
        }
    }
}
