using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFrutas : MonoBehaviour
{
    public GameObject gameObject;
    public List<ConfiguracionFruta> configuracionFrutas;
    private GameObject spawnedRaindrop;

    void Start()
    {
        Invoke("SpawnRaindrop", 1);
    }

    void Update()
    {

    }

   public void SpawnRaindrop()
    {
        ConfiguracionFruta configuracion = configuracionFrutas[Random.Range(0, 8)];

        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        spawnedRaindrop = Instantiate(gameObject, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = spawnedRaindrop.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -configuracion.velocidad);

        SpriteRenderer spriteRenderer = spawnedRaindrop.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = configuracion.sprites[Random.Range(0, configuracion.sprites.Length)];
    }
}
