using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Destroy : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    public GameObject ManchaDeTinta;
    public MovimientoPersonaje movInvertido;
    public GameObject Cesta;
    public GameObject Aspiradora;
    public GameObject Invertido;
    public GameObject Multiplicador;
    public GameObject Chrono;
    public GameObject Barrera;
    public GameObject EscudoBarrera;
    public Image Sangre;
    private float r;
    private float g;
    private float b;
    private float a;
    public float scaleX = 0.8f;
    public float newScaleX;
    public float scaleY = 0.8f;
    public float newScaleY;
    public float pos = 10.5f;
    public float newPos;
    public AudioClip agujeroNegro;
    public AudioClip QuitarVida;
    public AudioClip Recolecta;
    public TMP_Text comboText;
    private int comboCount = 0;


    void Start()
    {
        r = Sangre.color.r;
        g = Sangre.color.g;
        b = Sangre.color.b;
        a = Sangre.color.a;
         

    }

    private void Awake()
    {
        //scaleX = 0.8f;
        //scaleY = 0.8f;
        //pos = 10.5f;
        PlayerPrefs.SetFloat("scaleX", scaleX);
        PlayerPrefs.SetFloat("scaleY", scaleY);
        PlayerPrefs.SetFloat("pos", pos);
        UpdateBasket();
    }
    private void Update()
    {
        a -= 0.30f * Time.deltaTime;
        a = Mathf.Clamp(a, 0f, 0.35f);
        ChangeColor();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource myAudioSource = GetComponent<AudioSource>();
        if (collision.gameObject.CompareTag("Fruta"))
        {
            int configuracionFrutaID = GetConfiguracionFruta(collision.gameObject);

            if (configuracionFrutaID != -1 && configuracionFrutaID < configuracionFrutas.Count)
            {
                ConfiguracionFruta configuracionFruta = configuracionFrutas[configuracionFrutaID];

                puntuacion.punt += (int)configuracionFruta.gold;

                RecolectarFruta(configuracionFrutaID);
                RecolectarFrutaDefeat(configuracionFrutaID);

                comboCount++;
                if (comboCount >= 2)
                {
                    comboText.gameObject.SetActive(true);
                    //comboText.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-0.5f, 5));
                }
                comboText.text = "x" + comboCount;
               
            }   

            else
            {
                Debug.LogWarning("Índice de configuraciones fuera de rango. Asegúrate de tener configuraciones para todas las frutas.");
            }
            
            myAudioSource.PlayOneShot(Recolecta);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {
            if (!Barrera.activeSelf)
            {
                Destroy(collision.gameObject);
                myAudioSource.PlayOneShot(QuitarVida);
                puntuacion.life -= 1;
                a += 0.35f;
                a = Mathf.Clamp(a, 0f, 0.35f);
                ChangeColor();
                comboCount = 0;
                comboText.gameObject.SetActive(false);
                comboText.text = "x" + 0;
            }
            else
            {
                Destroy(collision.gameObject);
            }

        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            SpawnPowerUp num = FindObjectOfType<SpawnPowerUp>();
            if (num.powerUpSelected == 1)
            {
                Destroy(collision.gameObject);
                ManchaDeTinta.SetActive(true);
                StartCoroutine(QuitarTinta(3f));
            }
            else if (num.powerUpSelected == 2)
            {
                Destroy(collision.gameObject);
                movInvertido.Invertido();
                Invertido.SetActive(true);
                StartCoroutine(DesactivarInvertir(4f));
                StartCoroutine(QuitarEvento(2f));
            }
            else if (num.powerUpSelected == 3)
            {
                Aspiradora.SetActive(true);
                myAudioSource.PlayOneShot(agujeroNegro);
                Aspiradora aspirar = FindObjectOfType<Aspiradora>();
                aspirar.Aspirar();
                Destroy(collision.gameObject);
                StartCoroutine(ActivarAspiradora(5f));
            }
            else if (num.powerUpSelected == 4)
            {
                Destroy(collision.gameObject);
                Multiplicador.SetActive(true);
                StartCoroutine(QuitarEvento(2f));
                foreach (ConfiguracionFruta configuracionx2 in configuracionFrutas)
                {
                    configuracionx2.gold *= 2;
                }
                StartCoroutine(DesactivarMultiplicador(6f));
            }
            else if (num.powerUpSelected == 5)
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
            else if (num.powerUpSelected == 6)
            {
                Destroy(collision.gameObject);
                Barrera.SetActive(true);
                EscudoBarrera.SetActive(true);
                StartCoroutine(QuitarBarrera(5f));
                StartCoroutine(QuitarEvento(2f));
            }
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

        Invertido.SetActive(false);
        Multiplicador.SetActive(false);
        Chrono.SetActive(false);
        EscudoBarrera.SetActive(false);
    }

    public IEnumerator QuitarTinta(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        ManchaDeTinta.SetActive(false);
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

    public void UpdateBasket()
    {
        newScaleX = PlayerPrefs.GetFloat("newScaleX");
        newScaleY = PlayerPrefs.GetFloat("newScaleY");
        newPos = PlayerPrefs.GetFloat("newPos");
        //newScaleX = 0.8f;
        //newScaleY = 0.8f;
        //newPos = 10.5f;
        scaleX = newScaleX;
        scaleY = newScaleY;
        pos = newPos;
        PlayerPrefs.SetFloat("scaleX", scaleX);
        PlayerPrefs.SetFloat("scaleY", scaleY);
        PlayerPrefs.SetFloat("pos", pos);

        Cesta.transform.localScale = new Vector3(scaleX, scaleY, 1f);
        Cesta.transform.localPosition = new Vector3(Cesta.transform.localPosition.x, pos, Cesta.transform.localPosition.z);
    }

    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        Sangre.color = c;
    }
}
