using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInUI : MonoBehaviour
{
    public CanvasGroup canvas;

    void Start()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        while (canvas.alpha < 1.0f)
        {
            canvas.alpha += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
