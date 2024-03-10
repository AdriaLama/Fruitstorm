using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemies : MonoBehaviour
{
    public GameObject balaPrefab;
    public float intervaloDisparo = 3f;
    Collider2D coll;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        if (coll.CompareTag("MiniBoss") || coll.CompareTag("MiniBoss2"))
        {
            intervaloDisparo = 2f;
        }
        if (coll.CompareTag("Boss"))
        {
            intervaloDisparo = 1f;
        }
        InvokeRepeating("Disparar", 0f, intervaloDisparo);
    }
    void Disparar()
    {
        GameObject temp = Instantiate(balaPrefab, transform.position, transform.rotation);
        Destroy(temp, 1);
    }
}
