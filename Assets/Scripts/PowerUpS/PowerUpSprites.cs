using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSprites : MonoBehaviour
{
    public List<ConfiguracionPowerUps> configuracionPowerUps;
    public int id = 1;
    public void SpawnPowerUps()
    {
        id = Random.Range(0, 6);
        ConfiguracionPowerUps configuracion = configuracionPowerUps[id];

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = configuracion.sprite;
    }
}
