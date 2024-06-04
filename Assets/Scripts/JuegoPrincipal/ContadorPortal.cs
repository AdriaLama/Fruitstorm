using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorPortal : MonoBehaviour
{
    public float currTime = 0;
    public float spawnTime = 1f;
    public bool setPortal = false;
    public bool hasTP = false;
    public GameObject portal;
    public GameObject portal2;
    public GameObject teleport;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currTime > spawnTime && !setPortal)
            {
                setPortal = true;
                Vector3 position = player.transform.position;
                position.y -= 1.0f;
                portal.transform.position = position;
            }
            else if (setPortal)
            {
                setPortal = false;
                StartCoroutine(Teleport());
            }
        }

        if (setPortal)
        {
            portal.SetActive(true);
            cooldownPortal.SetActive(false);
            cooldownPortalActivo.SetActive(true);
        }
        if (hasTP)
        {
            cooldownPortalActivo.SetActive(false);
            portal.SetActive(false);
            currTime = 0;
            StartCoroutine(countdownPortal());
            hasTP = false;
        }
    }

    public IEnumerator Teleport()
    {
        teleport.SetActive(true);
        portal2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Vector3 playerPosition = portal.transform.position;
        playerPosition.y += 1.0f;
        player.transform.position = playerPosition;
        teleport.SetActive(false);
        portal2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        hasTP = true;
    }

    public IEnumerator countdownPortal()
    {
        int countdown = 10;
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
