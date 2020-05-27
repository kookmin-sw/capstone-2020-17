using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buaak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spread");
    }

    IEnumerator Spread()
    {
        iTween.RotateBy(this.gameObject, iTween.Hash("y", 40/360f, "easeType", iTween.EaseType.easeInOutSine, "time", 3.0f, "loopType", iTween.LoopType.pingPong));
        yield return 0;
    }
}
