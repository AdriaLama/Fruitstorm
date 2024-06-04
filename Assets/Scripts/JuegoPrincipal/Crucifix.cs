using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucifix : MonoBehaviour
{
    public float radioAtracción;
    public float fuerzaAtracción;
    public float velocidadMaxima;
    public GameObject Crucifijo;
    private bool atrayendo = true;

    void FixedUpdate()
    {
        if (Crucifijo.activeSelf)
        {
            Collider2D[] Frutas = Physics2D.OverlapCircleAll(transform.position, radioAtracción);
            foreach (Collider2D objeto in Frutas)
            {
                if (objeto.CompareTag("Fruta"))
                {
                    Rigidbody2D rb = objeto.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        if (atrayendo)
                        {
                          
                            Vector2 dirección = transform.position - objeto.transform.position;
                            float distancia = dirección.magnitude;
                            if (distancia <= radioAtracción)
                            {
                               
                                Vector2 velocidadDeseada = dirección.normalized * velocidadMaxima;

                              
                                Vector2 fuerzaNecesaria = (velocidadDeseada - rb.velocity) * rb.mass / Time.fixedDeltaTime;

                                
                                rb.AddForce(fuerzaNecesaria);
                            }
                        }
                        else
                        {

                            rb.gravityScale = 1f;
                        }
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Fruta"))
        {
            atrayendo = false;
        }
    }

   
}
