using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction1_2 : MonoBehaviour
{
    public GameObject vrCam;
    public GameObject[] ui1;
    public GameObject[] ui2;
    public GameObject[] ui_floor;
    public GameObject fireAlarm;
    public Behaviour halo;
    public GameObject waterfall;
    public GameObject rug;
    public GameObject rug_wet;

    public Vector3 destination1;
    public Vector3 destination2;
    public Vector3 destination3;

    public void SelectBtn1()
    {
        ui1[0].SetActive(false);
        ui1[1].SetActive(true);
        StartCoroutine("MoveCam1");
    }

    public void SelectBtn2_1()
    {
        ui2[0].SetActive(false);
        ui2[1].SetActive(true);
    }

    public void SelectBtn2_2()
    {
        ui2[1].SetActive(false);
        ui2[2].SetActive(true);
        ui2[3].SetActive(true);
    }

    public void SelectBtn_floor()
    {
        ui_floor[0].SetActive(false);
        // 계단을 통해 한 층 아래로 이동
        StartCoroutine("MoveCam4");
    }

    public void SelectBtn_floor2()
    {
        ui_floor[1].SetActive(false);
        // 다시 위층으로 이동
        StartCoroutine("MoveCam5");
    }
    public void SelectBtn_floor3()
    {
        StartCoroutine("MoveCam7");
    }


    public IEnumerator MoveCam1()
    {
        yield return new WaitForSeconds(7.0f);
        iTween.MoveBy(vrCam, iTween.Hash("z", 4.25f, "easeType", iTween.EaseType.easeInOutSine, "time", 9.0f)); // 비상벨까지 이동
    }

    public IEnumerator MoveCam2()
    {
        yield return new WaitForSeconds(5.0f);
        iTween.MoveBy(vrCam, iTween.Hash("x", -10, "easeType", iTween.EaseType.easeInOutSine, "time", 16.0f)); // 수돗가까지 이동
    }

    public IEnumerator WaitForWater()
    {
        yield return new WaitForSeconds(6.0f);
        waterfall.SetActive(false);  // 물 끄기
        rug_wet.SetActive(false);
        StartCoroutine("MoveCam3");
    }
    public IEnumerator MoveCam3()
    {
        yield return new WaitForSeconds(5.0f);
        iTween.MoveBy(vrCam, iTween.Hash("x", -4.0f, "easeType", iTween.EaseType.easeInOutSine, "time", 10.0f)); // 계단까지 이동

    }
    public IEnumerator MoveCam4()
    {
        iTween.MoveBy(vrCam, iTween.Hash("z", -3.0f, "easeType", iTween.EaseType.easeInOutSine, "time", 7.0f)); // 계단 앞까지 이동
        yield return new WaitForSeconds(8.0f);
        iTween.MoveTo(vrCam, iTween.Hash("position", destination1, "easeType", iTween.EaseType.easeInOutSine, "time", 10.0f));   // 한 층 아래로 이동

    }
    public IEnumerator MoveCam5()
    {
        // 불길 때문에 다시 돌아감
        yield return new WaitForSeconds(3.0f);
        iTween.MoveTo(vrCam, iTween.Hash("position", destination2, "easeType", iTween.EaseType.easeInOutSine, "time", 10.0f));
        yield return new WaitForSeconds(11.0f);
        StartCoroutine("MoveCam6");
    }
    public IEnumerator MoveCam6()
    {
        iTween.MoveBy(vrCam, iTween.Hash("x", -2.6f, "easeType", iTween.EaseType.easeInOutSine, "time", 5.0f)); // 윗 계단까지 이동
        yield return new WaitForSeconds(6.0f);
        // 한층 올라감
        iTween.MoveTo(vrCam, iTween.Hash("position", destination3, "easeType", iTween.EaseType.easeInOutSine, "time", 10.0f));
    }


    public void OnSelected(Transform t)
    {
        if (t.gameObject.CompareTag("Alarm") || t.gameObject.name == "Alarm")
        {
            halo.enabled = true;    // 비상벨 켜기
            StartCoroutine("MoveCam2");
        }
        if (t.gameObject.CompareTag("Rug") || t.gameObject.name == "Rug")
        {
            // 수건 줍기
            ui2[3].SetActive(false);
            ui2[4].SetActive(true); // 개수대 ui 켜기
            rug.SetActive(false);
        }

        if (t.gameObject.CompareTag("Sink") || t.gameObject.name == "Sink")
        {
            ui2[4].SetActive(false); // 개수대 ui 끄기
            waterfall.SetActive(true);  // 물 틀기
            rug_wet.SetActive(true);    // 적셔
            StartCoroutine("WaitForWater");
        }

    }
}
