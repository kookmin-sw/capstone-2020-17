using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutUI : MonoBehaviour
{
    public CanvasGroup canvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FadeInOut");
    }

    IEnumerator FadeInOut()
    {
        while (canvas.alpha < 1.0f)
        {
            canvas.alpha += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(6.0f);

        while (canvas.alpha > 0.0f) {
            canvas.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
