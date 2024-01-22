using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFrutas : MonoBehaviour
{
    public GameObject raindropPrefab;
    public float raindropSpeed;

    void Start()
    {
        Invoke("SpawnRaindrop", 1);
    }

    void Update()
    {
      
    }

   public void SpawnRaindrop()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        GameObject raindrop = Instantiate(raindropPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = raindrop.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -raindropSpeed);
    }
}
