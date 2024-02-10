using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PowerUpTinta : MonoBehaviour
{
    public GameObject Tinta;
    private GameObject spawnedTinta;
    public float currTime;
    public float spawnTime;
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
}
