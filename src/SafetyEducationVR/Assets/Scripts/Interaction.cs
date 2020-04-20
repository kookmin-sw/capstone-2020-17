using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject vrCam;
    public GameObject ui1_1;
    public GameObject ui1_2;
    public GameObject phoneUI1;
    public GameObject phoneUI2;
    public GameObject phone;
    public GameObject flammableUI;
    public GameObject flammableUI_1;
    public GameObject flammableUI_2;
    public GameObject flammable;

    public void PushBtn1_1()
    {
        ui1_1.SetActive(false);
        ui1_2.SetActive(true);
        StartCoroutine("WaitForUI1");
    }

    IEnumerator WaitForUI1()
    {
        yield return new WaitForSeconds(7.0f);  // UI1_2 사라질 때까지 대기
        iTween.MoveBy(vrCam, iTween.Hash("z", 3, "easeType", iTween.EaseType.easeInOutSine, "time", 9.0f)); // 휴대전화까지 이동
    }

    IEnumerator GoToFlammable()
    {
        yield return new WaitForSeconds(10.0f);
        iTween.MoveBy(vrCam, iTween.Hash("z", 3.5, "easeType", iTween.EaseType.easeInOutSine, "time", 9.0f)); // 인화물질까지 이동
    }

    IEnumerator GoToFire()
    {
        yield return new WaitForSeconds(10.0f);
        iTween.MoveBy(vrCam, iTween.Hash("z", 2.5, "easeType", iTween.EaseType.easeInOutSine, "time", 6.0f)); // 불 앞까지 이동
    }

    public void OnSelected(Transform t)
    {
        if (t.gameObject.CompareTag("Phone") || t.gameObject.name == "Smartphone")
        {
            phoneUI2.SetActive(true);
            phoneUI1.SetActive(false);
            StartCoroutine("GoToFlammable");
            phone.SetActive(false);
        }

        if(t.gameObject.CompareTag("Flammable") || t.gameObject.name == "Flammable")
        {
            flammableUI_1.SetActive(false);
            flammableUI_2.SetActive(true);
            StartCoroutine("GoToFire");
            flammable.SetActive(false);

        }
    }
}
