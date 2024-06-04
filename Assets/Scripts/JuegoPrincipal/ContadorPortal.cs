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
    public GameObject cooldownPortal;
    public GameObject cooldownPortalActivo;
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
            portal.transform.position = player.transform.position;
            portal.SetActive(true);
            cooldownPortal.SetActive(false);
            cooldownPortalActivo.SetActive(true);
          
        }

        if (portal.activeSelf && Input.GetKey(KeyCode.E))
        {
            player.transform.position = portal.transform.position;
            cooldownPortalActivo.SetActive(false);
            portal.SetActive(false);
            currTime = 0;
            StartCoroutine(countdownPortal());


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


}
