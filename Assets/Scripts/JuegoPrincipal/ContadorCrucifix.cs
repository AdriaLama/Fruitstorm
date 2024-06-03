using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class ContadorCrucifix : MonoBehaviour
{
    public float currTime = 0;
    public float spawnTime = 1f;
    public GameObject crucifix;
    public float time;
    public float disappearTime;
    public GameObject cooldownCrucifix;
    public TMP_Text contCrucifix;

    private void Start()
    {
        StartCoroutine(countdownCrucifix());
    }
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > spawnTime && Input.GetKey(KeyCode.E))
        {
            currTime = 0;
            crucifix.SetActive(true);
            StartCoroutine(countdownCrucifix());
            crucifix.transform.position = new Vector3(Random.Range(-6.4f, 11.5f), Random.Range(3.7f, 6f));

        }

        if (crucifix.activeSelf)
        {
            time += Time.deltaTime;

            cooldownCrucifix.SetActive(false);

            if (time >= disappearTime)
            {
                time = 0;
                crucifix.SetActive(false);


            }
        }



    }

    public IEnumerator countdownCrucifix()
    {
        int countdown = 10;
        contCrucifix.gameObject.SetActive(true);

        while (countdown > 0)
        {
            contCrucifix.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }

        if (countdown >= 0)
        {
            cooldownCrucifix.SetActive(true);
            contCrucifix.gameObject.SetActive(false);
        }
    }
}
