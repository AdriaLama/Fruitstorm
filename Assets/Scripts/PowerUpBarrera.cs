using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBarrera : MonoBehaviour
{
    public GameObject Barrera;
    private GameObject spawnedBarrera;
    public float currTime;
    public float spawnTime;

    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnBarrera();
        }
    }

    public void SpawnBarrera()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedBarrera = Instantiate(Barrera, spawnPosition, Quaternion.identity);
    }
}

