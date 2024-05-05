using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaLaser : MonoBehaviour
{
    Rigidbody2D rigidB;
    public float bulletSpeed;
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        rigidB.AddForce(transform.right * bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UISpace punt = FindObjectOfType<UISpace>();
        if (collision.gameObject.tag == "Player")
        {
            punt.life-=3;
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
