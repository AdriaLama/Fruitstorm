using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorVaca : MonoBehaviour
{
    public float currTime = 0;
    public float spawnTime = 1f;
    public GameObject vaca;
    public float time;
    public float disappearTime;
   
   

    void Start()
    {

    }

    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > spawnTime && Input.GetKey(KeyCode.E))
        {
            currTime = 0;
            vaca.SetActive(true);
        }

        if (vaca.activeSelf)
        {
            time += Time.deltaTime;

            if (time >= disappearTime)
            {
                time = 0;
                vaca.SetActive(false);

            }
        }

    }
}
