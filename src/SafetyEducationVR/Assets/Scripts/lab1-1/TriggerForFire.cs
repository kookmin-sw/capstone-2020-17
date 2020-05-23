using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForFire : MonoBehaviour
{
    public GameObject extinguisherUI;

    private void OnTriggerEnter(Collider other)
    {
        extinguisherUI.SetActive(true);
    }
}
