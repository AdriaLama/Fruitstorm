using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    public Animator animator;


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
            Destroy(collision.gameObject);
            animator.SetBool("Bomb", true);
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
}
