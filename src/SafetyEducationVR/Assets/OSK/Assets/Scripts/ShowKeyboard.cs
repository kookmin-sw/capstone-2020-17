using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeyboard : MonoBehaviour
{
    public GameObject keyboard;

    public void OnClickBtn()
    {
        keyboard.SetActive(true);
    }
}
