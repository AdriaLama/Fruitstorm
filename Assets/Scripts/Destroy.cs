using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public UI puntuacion;
    private ConfiguracionFruta configuracionActual;
    public List<ConfiguracionFruta> configuracionFrutas;
    public GameObject ManchaDeTinta;
    public MovimientoPersonaje movInvertido;
    public GameObject Rifle;
    public GameObject Alien;
    public GameObject Aspiradora;
    

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
        if (collision.gameObject.CompareTag("Bomba"))
        {
            Destroy(collision.gameObject);

            puntuacion.life -= 1;


        }

        if (collision.gameObject.CompareTag("PowerUpTinta"))
        {
            Destroy(collision.gameObject);
            ManchaDeTinta.SetActive(true);
            StartCoroutine(DesactivarSprite(4f));
        }

        if (collision.gameObject.CompareTag("PowerUpInvertir"))
        {
            Destroy(collision.gameObject);
            movInvertido.Invertido();
            StartCoroutine(DesactivarInvertir(4f));
        }

        if (collision.gameObject.CompareTag("PowerUpArma"))
        {
            Rifle.SetActive(true);
            Destroy(collision.gameObject);
            Alien.SetActive(true);
        }
        if (collision.gameObject.CompareTag("PowerUpAspiradora"))
        {
            Aspiradora.SetActive(true);
            Aspiradora aspirar = FindObjectOfType<Aspiradora>();
            aspirar.Aspirar();
            Destroy(collision.gameObject);
            StartCoroutine(ActivarAspiradora(8f));
        }
    }
    public IEnumerator DesactivarSprite(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ManchaDeTinta.SetActive(false);
    }
    public IEnumerator DesactivarInvertir(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        movInvertido.Invertido();
    }
    public IEnumerator ActivarAspiradora(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Aspiradora aspirar = FindObjectOfType<Aspiradora>();
        aspirar.Aspirar();
        Aspiradora.SetActive(false);
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
