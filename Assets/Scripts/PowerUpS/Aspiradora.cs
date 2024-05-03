using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspiradora : MonoBehaviour
{
    public float radioAtracci�n = 6f;
    public float fuerzaAtracci�n = 12.5f;

    private bool activado = false;

    void Update()
    {
        if (activado)
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
                        rb.AddForce(direcci�n.normalized * fuerzaAtracci�n);
                    }
                }
            }
        }
    }

    public void Aspirar()
    {
        activado = !activado;
    }
}
