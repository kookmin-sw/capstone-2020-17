using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForWater : MonoBehaviour
{
    public GameObject waterUI;


    private void OnTriggerEnter(Collider other)
    {
        waterUI.SetActive(true);
    }
}
