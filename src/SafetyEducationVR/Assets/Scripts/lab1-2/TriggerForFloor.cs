using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForFloor : MonoBehaviour
{
    public GameObject floorUI;

    private void OnTriggerEnter(Collider other)
    {
        floorUI.SetActive(true);
    }
}
