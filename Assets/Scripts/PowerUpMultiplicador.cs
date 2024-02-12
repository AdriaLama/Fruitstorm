using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMultiplicador : MonoBehaviour
{
    public GameObject Multiplicador;
    private GameObject spawnedMultiplicador;
    public float currTime;
    public float spawnTime;


    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnMultiplicador();
        }
    }

    public void SpawnMultiplicador()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedMultiplicador = Instantiate(Multiplicador, spawnPosition, Quaternion.identity);
    }
}
