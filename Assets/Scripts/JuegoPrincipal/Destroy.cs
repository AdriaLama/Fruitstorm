using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;


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
    public GameObject BombasSpeed;
    public GameObject PjSpeed;
    public GameObject MainCamera;
    public Image Sangre;
    private float r;
    private float g;
    private float b;
    private float a;
    public AudioClip agujeroNegro;
    public AudioClip QuitarVida;
    public AudioClip Recolecta;
    public AudioClip MoneyGain;
    public AudioSource quitarVida;
    public AudioSource Dinero;
    public TMP_Text comboText;
    public GameObject comboTextObject;
    public float goldGained;
    public int comboCount = 0;
    public int comboGold = 0;
    public int totalComboGold = 0;
    public ParticleSystem particulas;
    public GameObject Star;
    public AudioSource recolecta;
    private GameObject DineroGanado;
    public TMP_Text TextoDineroGanado;
    public float scaleX;
    public float scaleY;
    public float posY;

    void Start()
    {
        scaleX = GameManager.Instance.basketScaleX;
        scaleY = GameManager.Instance.basketScaleY;
        posY = GameManager.Instance.basketPosY;
        r = Sangre.color.r;
        g = Sangre.color.g;
        b = Sangre.color.b;
        a = Sangre.color.a;
        Cesta.transform.localScale = new Vector3(scaleX, scaleY, 10);
    }
    private void Update()
    {
        scaleX = GameManager.Instance.basketScaleX;
        scaleY = GameManager.Instance.basketScaleY;
        posY = GameManager.Instance.basketPosY;
        a -= 0.30f * Time.deltaTime;
        a = Mathf.Clamp(a, 0f, 0.35f);
        ChangeColor();
        comboText.text = "x" + comboCount;
        TextoDineroGanado.text = "+" + goldGained;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
       
        if (collision.gameObject.CompareTag("Fruta"))
        {
            int configuracionFrutaID = GetConfiguracionFruta(collision.gameObject);

            if (configuracionFrutaID != -1 && configuracionFrutaID < configuracionFrutas.Count)
            {
                ConfiguracionFruta configuracionFruta = configuracionFrutas[configuracionFrutaID];

                puntuacion.punt += (int)configuracionFruta.gold;

                comboGold += (int)configuracionFruta.gold;

                RecolectarFruta(configuracionFrutaID);
                RecolectarFrutaDefeat(configuracionFrutaID);

                comboCount++;
                if (comboCount >= 2)
                {
                    comboText.gameObject.SetActive(true);
                    comboTextObject.transform.localPosition = new Vector3(Random.Range(0, 800), Random.Range(-300, 0), 10);
                    comboText.transform.localRotation = Quaternion.Euler(new Vector3(0, 30, Random.Range(-30, 30)));
                    comboText.GetComponent<TextMeshProUGUI>().fontSize += 0.1f * Time.deltaTime;

                    if (recolecta.pitch < 2.5)
                    {
                        recolecta.pitch += 0.20f;
                    }
                    
                }

                particulas.Play();
                GameObject temp = Instantiate(Star, new Vector2(collision.transform.position.x, collision.transform.position.y - 0.5f), collision.transform.rotation);
                Destroy(temp, 0.25f);

            }   

            else
            {
                Debug.LogWarning("Índice de configuraciones fuera de rango. Asegúrate de tener configuraciones para todas las frutas.");
            }
            
            recolecta.PlayOneShot(Recolecta);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {
            if (!Barrera.activeSelf)
            {
                Destroy(collision.gameObject);
                quitarVida.PlayOneShot(QuitarVida);
                puntuacion.life -= 1;
                a += 0.35f;
                a = Mathf.Clamp(a, 0f, 0.35f);
                ChangeColor();
                if (comboCount >= 2 )
                {
                    Dinero.PlayOneShot(MoneyGain);
                    goldGained = comboGold * comboCount;
                    TextoDineroGanado.gameObject.SetActive(true);
                    TextoDineroGanado.transform.localPosition = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);
                    StartCoroutine(QuitarDinero(1f));
                }
                totalComboGold += comboCount * comboGold;
                puntuacion.punt = totalComboGold;
                comboCount = 0;
                comboGold = 0;
                comboText.gameObject.SetActive(false);
                recolecta.pitch = 1f;
                particulas.Play();
                
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
                quitarVida.PlayOneShot(agujeroNegro);
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
            else if (num.powerUpSelected == 7)
            {
                Destroy(collision.gameObject);
                BombasSpeed.SetActive(true);
                SpawnBombas s = FindObjectOfType<SpawnBombas>();
                s.spawnTime = 0.25f;
                StartCoroutine(DesactivarBomba(5f));
                StartCoroutine(QuitarEvento(2f));
            }
            else if (num.powerUpSelected == 8)
            {
                Destroy(collision.gameObject);
                MainCamera.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                movInvertido.Invertido();
                StartCoroutine(DesactivarCamara(5f));
            }
            else if (num.powerUpSelected == 9)
            {
                Destroy(collision.gameObject);
                PjSpeed.SetActive(true);
                MovimientoPersonaje mp = FindObjectOfType<MovimientoPersonaje>();
                mp.speed += 5;
                StartCoroutine(DesactivarSpeed(5f));
                StartCoroutine(QuitarEvento(2f));
            }
        }
    }
    public IEnumerator DesactivarInvertir(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        movInvertido.Invertido();
    }
    public IEnumerator DesactivarCamara(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        MainCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        movInvertido.Invertido();

    }

    public IEnumerator DesactivarSpeed(float seconds) {
        yield return new WaitForSeconds(seconds);
        MovimientoPersonaje mp = FindObjectOfType<MovimientoPersonaje>();
        mp.speed -= 5;

    }
    public IEnumerator DesactivarBomba(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnBombas s = FindObjectOfType<SpawnBombas>();
        s.spawnTime = 1f;
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
        BombasSpeed.SetActive(false);
        PjSpeed.SetActive(false);
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

    public IEnumerator QuitarDinero(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        TextoDineroGanado.gameObject.SetActive(false);

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
    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        Sangre.color = c;
    }
}
