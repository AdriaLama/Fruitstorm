using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    public GameObject bala;
    Collider2D coll;
    private AudioSource audioSource;
    public AudioClip BalaNave;
    private float seconds;
    public float firerate = 0.25f;
    private bool isShooting;
    public Oleadas oleadas; // Referencia al script de Oleadas

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    void Update()
    {

        if (coll.enabled && !isShooting)
        {
            StartCoroutine(Disparar(seconds));
        }
    }

    public IEnumerator Disparar(float seconds)
    {
        isShooting = true;
        GameObject temp = Instantiate(bala, transform.position, transform.rotation);
        Destroy(temp, 1);
        AudioSource.PlayClipAtPoint(BalaNave, transform.position);
        yield return new WaitForSeconds(firerate);
        isShooting = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("MiniBoss") ||
            collision.CompareTag("Enemy2") || collision.CompareTag("MiniBoss2") ||
            collision.CompareTag("Boss"))
        {
            oleadas.EnemyDestroyed(collision.gameObject);
            Destroy(collision.gameObject);

        }
    }
}
