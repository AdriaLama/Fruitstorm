using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFrutas : MonoBehaviour
{
    public GameObject raindropPrefab;
    public float raindropSpeed;

    void Start()
    {
        // Inicia la lluvia en intervalos regulares
        Invoke("SpawnRaindrop", 1);
    }

    void Update()
    {
        // Puedes agregar lógica de juego aquí si es necesario
    }

   public void SpawnRaindrop()
    {
        // Crea una nueva gota de lluvia en una posición aleatoria en la parte superior de la pantalla
        Vector3 spawnPosition = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
        GameObject raindrop = Instantiate(raindropPrefab, spawnPosition, Quaternion.identity);

        // Configura la velocidad de la gota de lluvia
        Rigidbody2D rb = raindrop.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -raindropSpeed);
    }
}
