using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemies : MonoBehaviour
{
    Rigidbody2D rigidB;
    public float bulletSpeed;
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        rigidB.AddForce(-transform.up * bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovimientoNave player = FindObjectOfType<MovimientoNave>();
        if (collision.gameObject.tag == "Player")
        {
            player.shipLifes--;
            if (player.shipLifes <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (player.shipLifes > 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
