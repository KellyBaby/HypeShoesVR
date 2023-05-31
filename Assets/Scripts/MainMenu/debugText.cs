using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class debugText : MonoBehaviour
{
    public Text textComponent; // Reference to the Text component

    public void setText(string newText)
    {
        textComponent.text = newText;
    }
}
