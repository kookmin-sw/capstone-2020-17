using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForAlarm : MonoBehaviour
{
    public GameObject alarmUI;

    private void OnTriggerEnter(Collider other)
    {
        alarmUI.SetActive(true);
    }
}
