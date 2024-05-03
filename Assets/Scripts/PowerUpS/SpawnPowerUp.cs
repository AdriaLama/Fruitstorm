using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject PowerUp;
    public float currTime = 0;
    public float spawnTime = 1f;
    public int powerUpSelected;

    void Start()
    {
        powerUpSelected = Random.Range(1, 7);
    }
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnPowerUps();
        }
    }

    public void SpawnPowerUps()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        Instantiate(PowerUp, spawnPosition, Quaternion.identity);
    }
}
