using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyFruit : MonoBehaviour
{
    public UI puntuacion;
    private ConfiguracionFruta configuracionActual;
    public List<ConfiguracionFruta> configuracionFrutas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            int configuraciones = GetConfiguracionFruta(collision.gameObject);

            if (configuraciones >= 0 && configuraciones < configuracionFrutas.Count)
            {
                configuracionActual = configuracionFrutas[configuraciones];
                puntuacion.punt += (int)configuracionActual.gold;
            }
            else
            {
                Debug.LogWarning("Índice de configuraciones fuera de rango. Asegúrate de tener configuraciones para todas las frutas.");
            }

            Destroy(collision.gameObject);
        }
    }
    private int GetConfiguracionFruta(GameObject fruta)
    {
        FrutasSprites fruit = fruta.GetComponent<FrutasSprites>();
        if(fruit != null)
        {
            return fruit.id;
        }
        return -1;
    }
}
