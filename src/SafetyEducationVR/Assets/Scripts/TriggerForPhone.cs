using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForPhone : MonoBehaviour
{
    public GameObject phoneUI;
    private void OnTriggerEnter(Collider other)
    {
        phoneUI.SetActive(true);
    }
}
