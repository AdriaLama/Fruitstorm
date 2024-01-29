using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FrutasSprites : MonoBehaviour
{
    public List<ConfiguracionFruta> configuracionFrutas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SpawnRaindrop()
    {
        ConfiguracionFruta configuracion = configuracionFrutas[Random.Range(0, 8)];

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -configuracion.velocidad);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = configuracion.sprites[Random.Range(0, configuracion.sprites.Length)];
    }
}
