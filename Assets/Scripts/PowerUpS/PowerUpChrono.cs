using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpChrono : MonoBehaviour
{
    public GameObject Chrono;
    private GameObject spawnedChrono;
    public float currTime;
    public float spawnTime;


    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnChrono();
        }
    }

    public void SpawnChrono()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedChrono = Instantiate(Chrono, spawnPosition, Quaternion.identity);
    }
}
