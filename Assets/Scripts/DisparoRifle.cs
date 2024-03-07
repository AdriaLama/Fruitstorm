using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody2D rb;
    public float bullet_speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bullet_speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Alien")
        {
            Alien alien = FindObjectOfType<Alien>();
            alien.alienLifes--;
            
            if (alien.alienLifes <= 0) {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                UI uReady = FindObjectOfType<UI>();
                uReady.areUReady.SetActive(true);
            }
            else if (alien.alienLifes > 0)
            {
                Destroy(gameObject);
            }
            
        }
        if (collision.gameObject.tag == "Fruta")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bomba")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}