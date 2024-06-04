using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorPortal : MonoBehaviour
{
    public float currTime = 0;
    public float spawnTime = 1f;
    public GameObject portal;
    public GameObject player;
    public float time;
    public float disappearTime;
    public GameObject cooldownPortal;
    public TMP_Text contPortal;

    private void Start()
    {
        StartCoroutine(countdownPortal());
    }
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > spawnTime && Input.GetKey(KeyCode.E))
        {
            currTime = 0;
            Teletransport();
            portal.SetActive(true);
            StartCoroutine(countdownPortal());
            if (portal.activeSelf && Input.GetKey(KeyCode.E))
            {
                player.transform.position = portal.transform.position;
            }
        }

        if (portal.activeSelf)
        {
            time += Time.deltaTime;

            cooldownPortal.SetActive(false);

            if (time >= disappearTime)
            {
                time = 0;
                portal.SetActive(false);


            }
        }



    }

    public IEnumerator countdownPortal()
    {
        int countdown = 25;
        contPortal.gameObject.SetActive(true);

        while (countdown > 0)
        {
            contPortal.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;

        }

        if (countdown >= 0)
        {
            cooldownPortal.SetActive(true);
            contPortal.gameObject.SetActive(false);
        }
    }

    void Teletransport()
    {
        portal.transform.position = player.transform.position;

    }

}
