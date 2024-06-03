using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public GameObject Bala;
    Collider2D coll;
    public GameObject RiflePersonaje;
    public AudioSource Arma;
    public AudioClip Disparo;
    private SpriteRenderer sprite;

    void Start()
    {
        coll = GetComponent<Collider2D>();

        if (RiflePersonaje != null)
        {
            sprite = RiflePersonaje.GetComponent<SpriteRenderer>(); // Asegúrate de que RiflePersonaje tiene un SpriteRenderer
        }

    }

    void Update()
    {
        MovimientoPersonaje pj = FindObjectOfType<MovimientoPersonaje>();

        if (Input.GetButtonDown("Jump") && coll.enabled && RiflePersonaje.activeSelf)
        {
            GameObject temp = Instantiate(Bala, transform.position, transform.rotation);
            Destroy(temp, 1);
            Arma.PlayOneShot(Disparo);

           
        }

        if (sprite != null)
        {
            if (pj.horizontal > 0)
            {
                sprite.flipY = true;
            }
            else if (pj.horizontal < 0)
            {
                sprite.flipY = false;
            }
        }
    }
}
