using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvertir : MonoBehaviour
{
    public GameObject Invertir;
    private GameObject spawnedInvertir;
    public float currTime;
    public float spawnTime;

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnInvertir();
        }
    }

    public void SpawnInvertir()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedInvertir = Instantiate(Invertir, spawnPosition, Quaternion.identity);
    }
}