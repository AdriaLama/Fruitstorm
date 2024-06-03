using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucifix : MonoBehaviour
{
    public float radioAtracci�n;
    public float fuerzaAtracci�n;
    public float velocidadMaxima;
    public GameObject Crucifijo;


    void Update()
    {
        if (Crucifijo.activeSelf)
        {

            Collider2D[] Frutas = Physics2D.OverlapCircleAll(transform.position, radioAtracci�n);
            foreach (Collider2D objeto in Frutas)
            {
                if (objeto.CompareTag("Fruta"))
                {
                    Rigidbody2D rb = objeto.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        Vector2 direcci�n = transform.position - objeto.transform.position;
                        float distancia = direcci�n.magnitude;

                        float fuerzaModificada = fuerzaAtracci�n * Mathf.Clamp(distancia / radioAtracci�n, 0, 1);

                      
                        Vector2 fuerzaAplicada = direcci�n.normalized * fuerzaModificada;
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
