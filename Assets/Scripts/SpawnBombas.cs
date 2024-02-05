using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBombas : MonoBehaviour
{
    public GameObject Bomba;
    private GameObject[] spawnedBombas;
    public float currTime = 0;
    public float spawnTime = 1.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnBomba();
        }
    }

    public void SpawnBomba()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        int n = Random.Range(0,spawnedBombas.Length);
        Instantiate(spawnedBombas[n], spawnPosition, spawnedBombas[n].transform.rotation);
    }
}