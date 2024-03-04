using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject PowerUp;
    private GameObject spawnedPowerUps;
    public float currTime = 0;
    public float spawnTime = 1f;
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnRaindrop();
        }
    }

    public void SpawnRaindrop()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedPowerUps= Instantiate(PowerUp, spawnPosition, Quaternion.identity);
        spawnedPowerUps.GetComponent<PowerUpSprites>().SpawnPowerUps();
    }
}
