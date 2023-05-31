using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myDebug : MonoBehaviour
{
    private Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        //debugText=transform.Find("debugText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //debugText.text="www";
    }
    

    public void SetText(string text){
        //debugText.text=text;
    }


}
