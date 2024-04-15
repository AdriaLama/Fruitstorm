using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    public GameObject Bomba;
    public GameObject Explosion;
    public GameObject Explosion2;
    private Animator anim;
    private AudioSource audioSource;
    public AudioClip BombaAudio;

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

            Destroy(collision.gameObject, 2);
        }
        if (collision.gameObject.CompareTag("Bomba"))
        {

            if (!Explosion.activeSelf && !Explosion2.activeSelf)
            {
                Explosion.transform.position = collision.transform.position;
                AudioSource.PlayClipAtPoint(BombaAudio, transform.position);
                Destroy(collision.gameObject);
                Explosion.SetActive(true);
                StartCoroutine(QuitarExplosion(1f));
            }
            else if (Explosion.activeSelf && !Explosion2.activeSelf)
            {
                Explosion2.transform.position = collision.transform.position;
                AudioSource.PlayClipAtPoint(BombaAudio, transform.position);
                Destroy(collision.gameObject);
                Explosion2.SetActive(true);
                StartCoroutine(QuitarExplosion2(1f));
            }
            else if (!Explosion.activeSelf && Explosion2.activeSelf)
            {
                Explosion.transform.position = collision.transform.position;
                AudioSource.PlayClipAtPoint(BombaAudio, transform.position);
                Destroy(collision.gameObject);
                Explosion.SetActive(true);
                StartCoroutine(QuitarExplosion(1f));
            }

        }
        if (collision.gameObject.CompareTag("PowerUpInvertir"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUpTinta"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUpArma"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUpAspiradora"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUpMultiplicador"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUpChrono"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PowerUpBarrera"))
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
    public IEnumerator QuitarExplosion(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Explosion.SetActive(false);
    }
    public IEnumerator QuitarExplosion2(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Explosion2.SetActive(false);
    }
}
