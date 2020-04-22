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
    public GameObject extinguisher1;
    public GameObject extinguisher2;
    public GameObject extinguisherUI;
    public GameObject fireUI;
    public GameObject fireUI1_1;
    public GameObject fireUI1_2;
    public GameObject fireUI1_3;
    public GameObject fireUI1_4;
    public GameObject fireUI1_5;
    public GameObject fireCollider;
    public GameObject steam;

    public void PushBtn1_1()
    {
        ui1_1.SetActive(false);
        ui1_2.SetActive(true);
        StartCoroutine("WaitForUI1");
    }
    public void PushBtnFire1() {
        fireUI1_1.SetActive(false);
        fireUI1_2.SetActive(true);
    }
    public void PushBtnFire2() {
        fireUI1_2.SetActive(false);
        fireUI1_3.SetActive(true);
    }
    public void PushBtnFire3() {
        fireUI1_3.SetActive(false);
        fireUI1_4.SetActive(true);
    }
    public void PushBtnFire4()
    {
        fireUI1_4.SetActive(false);
        fireUI1_5.SetActive(true);
    }
    public void PushBtnFire5()
    {
        fireUI1_5.SetActive(false);
        fireCollider.SetActive(true);
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

    IEnumerator SteamPower()
    {
        steam.SetActive(true);  // 소화기 뿜뿜하기
        yield return new WaitForSeconds(8.0f);
        steam.SetActive(false);

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

        if (t.gameObject.CompareTag("Extinguisher") || t.gameObject.name == "Extinguisher")
        {
            extinguisher1.SetActive(false);
            extinguisher2.SetActive(true);
            extinguisherUI.SetActive(false);
            fireUI.SetActive(true);
        }
        if (t.gameObject.CompareTag("Fire") || t.gameObject.name == "FireCollider")
        {
            StartCoroutine("SteamPower");
        }

    }
}
