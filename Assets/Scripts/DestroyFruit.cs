using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            int configuraciones = GetConfiguracionFruta(collision.gameObject);
            Destroy(collision.gameObject);

            if (configuraciones >= 0 && configuraciones < configuracionFrutas.Count)
            {
                puntuacion.punt += (int)configuracionFrutas[configuraciones].gold;
            }
        }
    }
    private int GetConfiguracionFruta(GameObject fruta)
    {

        string tagFruta = fruta.tag;

        int configuraciones = configuracionFrutas.FindIndex(cf => cf.name == tagFruta);

        return configuraciones;
    }
}
