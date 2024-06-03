using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucifix : MonoBehaviour
{
    public float radioAtracción;
    public float fuerzaAtracción;
    public float velocidadMaxima;
    public GameObject Crucifijo;


    void Update()
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
                        Vector2 dirección = transform.position - objeto.transform.position;
                        float distancia = dirección.magnitude;

                        float fuerzaModificada = fuerzaAtracción * Mathf.Clamp(distancia / radioAtracción, 0, 1);

                      
                        Vector2 fuerzaAplicada = dirección.normalized * fuerzaModificada;
                        if (rb.velocity.magnitude < velocidadMaxima)
                        {
                            rb.AddForce(fuerzaAplicada);
                        }

                        if (distancia < 0.1f)
                        {
                            rb.velocity = Vector2.zero;
                            rb.angularVelocity = 0f;
                        }
                    }
                }
            }
        }
    }
}
