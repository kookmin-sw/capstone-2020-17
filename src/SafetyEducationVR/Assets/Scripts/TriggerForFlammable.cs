using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForFlammable : MonoBehaviour
{
    public GameObject flammableUI;

    private void OnTriggerEnter(Collider other)
    {
        flammableUI.SetActive(true);
    }

}
