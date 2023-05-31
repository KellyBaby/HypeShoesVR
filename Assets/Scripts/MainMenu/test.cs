using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private debugText mydebugText;
    // Start is called before the first frame update
    void Start()
    {
        mydebugText.setText("how");
    }

    // Update is called once per frame
    void Update()
    {
        mydebugText.setText("are");
    }
}
