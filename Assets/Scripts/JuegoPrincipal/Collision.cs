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
    private AudioSource audioSource;
    public AudioClip BombaAudio;
    public GameObject AnimBomba;
   

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2 (0, 0);
            
            int configuracionFrutaID = GetConfiguracionFruta(collision.gameObject);

            Destroy comb = FindObjectOfType<Destroy>();
            UI p = FindObjectOfType<UI>();
            comb.totalComboGold += comb.comboCount * comb.comboGold;
            p.punt = comb.totalComboGold;
            comb.comboCount = 0;
            comb.comboGold = 0;
            comb.comboText.gameObject.SetActive(false);

            Destroy(collision.gameObject, 2);
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {
            GameObject temp = Instantiate(AnimBomba, new Vector2(collision.transform.position.x, collision.transform.position.y - 0.5f), collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(temp, 0.15f);
            audioSource.PlayOneShot(BombaAudio);
        
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
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
}
