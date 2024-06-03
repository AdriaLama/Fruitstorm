using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;


public class CestaAnimal : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    public GameObject Cesta;
    public AudioClip Recolecta;
    public AudioClip MoneyGain;
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
 

    private void Update()
    {
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
                Debug.LogWarning("�ndice de configuraciones fuera de rango. Aseg�rate de tener configuraciones para todas las frutas.");
            }

            recolecta.PlayOneShot(Recolecta);
            Destroy(collision.gameObject);
        }
       
    }
    
    public int GetConfiguracionFruta(GameObject fruta)
    {
        FrutasSprites fruit = fruta.GetComponent<FrutasSprites>();
        if (fruit != null)
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
