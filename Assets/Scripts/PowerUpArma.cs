using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArma : MonoBehaviour
{
    public GameObject Arma;
    private GameObject spawnedArma;
    public float currTime;
    public float spawnTime;

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            SpawnArma();
        }

       
    }

    public void SpawnArma()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedArma = Instantiate(Arma, spawnPosition, Quaternion.identity);

        
    }


}
