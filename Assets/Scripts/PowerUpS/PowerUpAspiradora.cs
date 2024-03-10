using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAspiradora : MonoBehaviour
{
    public GameObject Aspiradora;
    private GameObject spawnedAspiradora;
    public float currTime;
    public float spawnTime;


    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnAspiradora();
        }
    }

    public void SpawnAspiradora()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedAspiradora = Instantiate(Aspiradora, spawnPosition, Quaternion.identity);
    }
}
