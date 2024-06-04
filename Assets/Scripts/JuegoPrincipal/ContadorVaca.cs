using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class ContadorVaca : MonoBehaviour
{
    public float currTime = 0;
    public float spawnTime = 1f;
    public GameObject vaca;
    public float time;
    public float disappearTime;
    public GameObject cooldownVaca;
    public TMP_Text contVaca;
    public AudioSource VacaAudio;

    private void Start()
    {
        StartCoroutine(countdownVaca());
    }
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > spawnTime && Input.GetKey(KeyCode.E))
        {
            currTime = 0;
            vaca.SetActive(true);
            VacaAudio.Play();
            StartCoroutine(countdownVaca());
            
        }

        if (vaca.activeSelf)
        {
            time += Time.deltaTime;

            cooldownVaca.SetActive(false);

            if (time >= disappearTime)
            {
                time = 0;
                vaca.SetActive(false);
               

            }
        }



    }

    public IEnumerator countdownVaca()
    {
        int countdown = 15;
        contVaca.gameObject.SetActive(true);

        while (countdown > 0)
        {
            contVaca.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }

        if (countdown >= 0)
        {
            cooldownVaca.SetActive(true);
            contVaca.gameObject.SetActive(false);
        }
    }
}
