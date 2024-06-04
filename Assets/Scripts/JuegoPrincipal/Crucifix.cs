using UnityEngine;

public class Crucifix : MonoBehaviour
{
    public float radioAtracción;
    public float fuerzaAtracción;
    public float velocidadMaxima;
    public GameObject Crucifijo;
    private bool atrayendo = true;
    private Rigidbody2D[] frutasRBs;

    void Start()
    {
        // Obtener los Rigidbody de todas las frutas
        frutasRBs = GameObject.FindObjectsOfType<Rigidbody2D>();
    }

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
                        Vector2 dirección = transform.position - objeto.transform.position;
                        float distancia = dirección.magnitude;
                        if (distancia <= radioAtracción)
                        {
                            // Calcula la velocidad deseada hacia el objeto
                            Vector2 velocidadDeseada = dirección.normalized * velocidadMaxima;

                            // Calcula la fuerza necesaria para alcanzar la velocidad deseada
                            Vector2 fuerzaNecesaria = (velocidadDeseada - rb.velocity) * rb.mass / Time.fixedDeltaTime;

                            // Aplica la fuerza necesaria
                            rb.AddForce(fuerzaNecesaria);
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
            Collider2D[] Frutas = Physics2D.OverlapCircleAll(transform.position, radioAtracción);
            foreach (Collider2D objeto in Frutas)
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 1f;
                }
              

            }
        }
    }

}
