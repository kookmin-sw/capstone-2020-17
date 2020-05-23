using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForPhone : MonoBehaviour
{
    public GameObject phoneUI;
    public CanvasGroup canvas;

    private void OnTriggerEnter(Collider other)
    {
        phoneUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine("FadeOutUI");
    }

    IEnumerator FadeOutUI()
    {
        yield return new WaitForSeconds(1.0f);

        while (canvas.alpha > 0.0f)
        {
            canvas.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
