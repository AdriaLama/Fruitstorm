using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Collision : MonoBehaviour
{
    GameObject Cesta;
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    public GameObject Bomba;
    private Animator anim;
    public AudioSource audioSource;
    public GameObject AnimBomba;
    private Rigidbody2D rb;
    public int randomDirection;
    public int speedDirection;
    private Destroy comb;
    public AudioSource recolecta;
    public AudioSource Dinero;
    public AudioClip MoneyGain;
    public AudioClip ErrorCombo;
    public AudioClip[] Bombas;



    private void Start()
    {
        
        comb = FindObjectOfType<Destroy>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2 (0, 0);
            
            int configuracionFrutaID = GetConfiguracionFruta(collision.gameObject);
            if (comb.comboCount >= 2 )
            {
                Dinero.PlayOneShot(MoneyGain);
                comb.goldGained = comb.comboGold * comb.comboCount;
                comb.TextoDineroGanado.gameObject.SetActive(true);
                comb.TextoDineroGanado.transform.localPosition = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);
                StartCoroutine(QuitarDinero(1f));
            }
            UI p = FindObjectOfType<UI>();
            comb.totalComboGold += comb.comboCount * comb.comboGold;
            p.punt = comb.totalComboGold;
            comb.comboCount = 0;
            comb.comboGold = 0;
            comb.comboText.gameObject.SetActive(false);
            recolecta.pitch = 1f;
            
            
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {
            GameObject temp = Instantiate(AnimBomba, new Vector2(collision.transform.position.x, collision.transform.position.y - 0.5f), collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(temp, 0.15f);
            audioSource.clip = Bombas[Random.Range(0, Bombas.Length)];
            audioSource.Play();

        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

           
            if (rb.velocity.magnitude == 0)
            {
                StartCoroutine(DestruirFruta(collision.gameObject));
            }
            else
            {
                
                StopCoroutine(DestruirFruta(collision.gameObject));
            }
        }
    }

    public IEnumerator QuitarDinero(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        comb.TextoDineroGanado.gameObject.SetActive(false);

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


    public IEnumerator DestruirFruta(GameObject fruta)
    {
        yield return new WaitForSeconds(1f); 

        if (fruta != null)
        {
            
            Destroy(fruta);
        }
    }
}
