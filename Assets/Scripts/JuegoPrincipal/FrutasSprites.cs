using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FrutasSprites : MonoBehaviour
{
    public List<ConfiguracionFruta> configuracionFrutas;
    public int id = 0;
    public void SpawnRaindrop()
    {
        id = Random.Range(0, 8);
        ConfiguracionFruta configuracion = configuracionFrutas[id];

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -configuracion.velocidad);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = configuracion.sprite;
    }
}
