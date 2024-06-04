using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        UISpace punt = FindObjectOfType<UISpace>();
        if (collision.gameObject.tag == "Player")
        {
            punt.life--;
            if (punt.life <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (punt.life > 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
