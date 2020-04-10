using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWNER : MonoBehaviour {

    public GameObject[] characters;
    public RuntimeAnimatorController F_anim;
    public RuntimeAnimatorController M_anim;
    float randomTime;
    float timeCounter;
    public float deviation;

    void Start ()
    {
        for (int i=0; i < characters.Length-1; i++)
        {
            if (i< characters.Length / 2)
                characters[i].GetComponent<Animator>().runtimeAnimatorController = F_anim as RuntimeAnimatorController;
            if (i > characters.Length / 2)
                characters[i].GetComponent<Animator>().runtimeAnimatorController = M_anim as RuntimeAnimatorController;
        }
    }
	
	
	void Update ()
    {
        if (timeCounter > randomTime)
        {
            Instantiate(characters[Random.Range(0, characters.Length-1)], transform.position + (transform.right * Random.Range(-1f, 1f)), transform.rotation * Quaternion.Euler(Vector3.up * Random.Range(-deviation, deviation)));
            randomTime = Random.Range(1, 4);
            timeCounter = 0f;
        }
        timeCounter += Time.deltaTime;
    }
}
