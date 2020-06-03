using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginBtn : MonoBehaviour
{
    public GameObject loginText1;
    public GameObject loginText2;
    public void Login()
    {
        StartCoroutine("ShowLoginText");
    }

    IEnumerator ShowLoginText()
    {
        loginText1.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        loginText1.SetActive(false);
        loginText2.SetActive(true);
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("MainSelect", LoadSceneMode.Single);
    }
}
