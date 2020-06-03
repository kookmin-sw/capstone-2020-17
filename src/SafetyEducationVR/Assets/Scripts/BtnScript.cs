using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public GameObject input1;
    public GameObject input2;

    public void PushBtnID()
    {
        input1.SetActive(true);
        input2.SetActive(false);
    }
    public void PushBtnPW()
    {
        input1.SetActive(false);
        input2.SetActive(true);
    }
}
