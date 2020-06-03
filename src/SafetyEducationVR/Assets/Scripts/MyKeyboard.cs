using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyKeyboard : MonoBehaviour
{
    public Text TextField;

    public void KeyFunction(string alphabet)
    {
        TextField.text += alphabet;
    }

    public void BackSpace()
    {
        if (TextField.text.Length > 0) TextField.text = TextField.text.Remove(TextField.text.Length - 1);
    }
}
