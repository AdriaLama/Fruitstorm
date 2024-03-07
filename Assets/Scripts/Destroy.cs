using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    public GameObject ManchaDeTinta;
    public MovimientoPersonaje movInvertido;
    public GameObject Rifle;
    public GameObject Cesta;
    public GameObject Alien;
    public GameObject Aspiradora;
    public GameObject Invertido;
    public GameObject Multiplicador;
    public GameObject Chrono;
    public GameObject Barrera;
    public GameObject EscudoBarrera;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Fruta"))
        {
            int configuracionFrutaID = GetConfiguracionFruta(collision.gameObject);

            if (configuracionFrutaID != -1 && configuracionFrutaID < configuracionFrutas.Count)
            {
                ConfiguracionFruta configuracionFruta = configuracionFrutas[configuracionFrutaID];

                puntuacion.punt += (int)configuracionFruta.gold;

                RecolectarFruta(configuracionFrutaID);
                RecolectarFrutaDefeat(configuracionFrutaID);
            }
            else
            {
                Debug.LogWarning("Índice de configuraciones fuera de rango. Asegúrate de tener configuraciones para todas las frutas.");
            }

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {
            if (!Barrera.activeSelf)
            {
                Destroy(collision.gameObject);

                puntuacion.life -= 1;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("PowerUpTinta"))
        {
            Destroy(collision.gameObject);
            ManchaDeTinta.SetActive(true);
            StartCoroutine(QuitarEvento(4f));
        }

        if (collision.gameObject.CompareTag("PowerUpInvertir"))
        {
            Destroy(collision.gameObject);
            movInvertido.Invertido();
            Invertido.SetActive(true);
            StartCoroutine(DesactivarInvertir(4f));
            StartCoroutine(QuitarEvento(2f));
        }

        if (collision.gameObject.CompareTag("PowerUpArma"))
        {
            Cesta.SetActive(false);
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
        if (collision.gameObject.CompareTag("PowerUpMultiplicador"))
        {
            Destroy(collision.gameObject);
            Multiplicador.SetActive(true);
            StartCoroutine(QuitarEvento(2f));
            foreach (ConfiguracionFruta configuracionx2 in configuracionFrutas)
            {
                configuracionx2.gold *= 2;           
            }
            StartCoroutine(DesactivarMultiplicador(5f));
        }
        if (collision.gameObject.CompareTag("PowerUpChrono"))
        {
            Destroy(collision.gameObject);
            Chrono.SetActive(true);
            StartCoroutine(QuitarEvento(2f));
            foreach (ConfiguracionFruta configuracionSlow in configuracionFrutas)
            {
                configuracionSlow.velocidad /= 2;
            }
            StartCoroutine(DesactivarSlow(5f));
        }
        if (collision.gameObject.CompareTag("PowerUpBarrera"))
        {
            Destroy(collision.gameObject);
            Barrera.SetActive(true);
            EscudoBarrera.SetActive(true);
            StartCoroutine(QuitarBarrera(5f));
            StartCoroutine(QuitarEvento(2f));

        }

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
    public IEnumerator DesactivarMultiplicador(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        foreach (ConfiguracionFruta configuracionx2 in configuracionFrutas)
        {
            configuracionx2.gold /= 2;
        }
    }
    public IEnumerator DesactivarSlow(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        foreach (ConfiguracionFruta configuracionx2 in configuracionFrutas)
        {
            configuracionx2.velocidad *= 2;
        }
    }
    public IEnumerator QuitarEvento(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ManchaDeTinta.SetActive(false);
        Invertido.SetActive(false);
        Multiplicador.SetActive(false);
        Chrono.SetActive(false);
        EscudoBarrera.SetActive(false);
    }
    public IEnumerator QuitarBarrera(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Barrera.SetActive(false);
    }
    public int GetConfiguracionFruta(GameObject fruta)
    {
        FrutasSprites fruit = fruta.GetComponent<FrutasSprites>();
        if(fruit != null)
        {
            return fruit.id;
        }
        return -1;
    }

    public void RecolectarFruta(int idFruta)
    {
        if (idFruta >= 0 && idFruta < puntuacion.collectedFrutas.Count)
        {
            puntuacion.collectedFrutas[idFruta]++;
        }
    }

    public void RecolectarFrutaDefeat(int idFruta)
    {
        if (idFruta >= 0 && idFruta < puntuacion.collectedFrutasDefeat.Count)
        {
            puntuacion.collectedFrutasDefeat[idFruta]++;
        }
    }
}
