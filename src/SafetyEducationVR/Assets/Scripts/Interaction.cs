using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject vrCam;
    public GameObject ui1_1;
    public GameObject ui1_2;

    public void PushBtn1_1()
    {
        ui1_1.SetActive(false);
        ui1_2.SetActive(true);
        StartCoroutine("WaitForUI1");
    }

    IEnumerator WaitForUI1()
    {
        yield return new WaitForSeconds(7.0f);  // UI1_2 사라질 때까지 대기
        iTween.MoveBy(vrCam, iTween.Hash("z", 3, "easeType", iTween.EaseType.easeInOutSine, "time", 10.0f)); // 휴대전화까지 이동
    }

    public void PushPhone()
    {

    }
}
