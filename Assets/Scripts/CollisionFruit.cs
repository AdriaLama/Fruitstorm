using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oll : MonoBehaviour
{
    public UI puntuacion;
    public List<ConfiguracionFruta> configuracionFrutas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2 (0, 0);

            collision.gameObject.transform.position = new Vector2 (collision.gameObject.transform.position.x, -2.8f);
            Destroy(collision.gameObject, 2);

            puntuacion.life++;
        }
    }
}
