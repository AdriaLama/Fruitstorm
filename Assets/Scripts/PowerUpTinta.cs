using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUpTinta : MonoBehaviour
{
    public GameObject Tinta;
    private GameObject spawnedTinta;
    public GameObject ManchaDeTinta;
    public float currTime;
    public float spawnTime;
    void Start()
    {
        ManchaDeTinta.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnTinta();
        }
    }

    public void SpawnTinta()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedTinta = Instantiate(Tinta, spawnPosition, Quaternion.identity);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Cesta"))
        {
            Destroy(gameObject);

            ManchaDeTinta.SetActive(true);

            StartCoroutine("DesactivarSprite");
        }


    }

    IEnumerator DesactivarSprite()
    {
        yield return new WaitForSeconds(5f);

        Destroy(ManchaDeTinta);
    }
}
