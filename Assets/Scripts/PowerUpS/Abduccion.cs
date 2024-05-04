using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abduccion : MonoBehaviour
{
    public float radioAtracción = 6f;
    public float fuerzaAtracción = 12.5f;
    public GameObject AlienRecolecta;
    

    void Update()
    {
        if (AlienRecolecta.activeSelf)
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
                        rb.AddForce(dirección.normalized * fuerzaAtracción);
                    }
                }
            }
        }
    }

    
}
