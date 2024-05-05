using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnFrutas : MonoBehaviour
{
    public GameObject Fruta;
    private GameObject spawnedRaindrop;
     private GameObject[] frutasSpawned;
    public int maxFrutas = 10;
    public float currTime = 0;
    public float spawnTime = 1f;
    public int randomRot;
    void Update()
    {
        currTime += Time.deltaTime;
        if(currTime > spawnTime)
        {
            currTime = 0;
            SpawnRaindrop();
            randomRot = Random.Range(1, 3);
        }
        if ( spawnedRaindrop != null )
        {
            if (randomRot == 1)
            {
                spawnedRaindrop.transform.Rotate(new Vector3(0, 0, 90f * Time.deltaTime), Space.Self);

            }
            if (randomRot == 2)
            {
                spawnedRaindrop.transform.Rotate(new Vector3(0, 0, -90f * Time.deltaTime), Space.Self);

            }
        }

        
    }

   public void SpawnRaindrop()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedRaindrop = Instantiate(Fruta, spawnPosition, Quaternion.identity);
        spawnedRaindrop.GetComponent<FrutasSprites>().Frutas();


    }
}
