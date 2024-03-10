using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody2D rigidB;
    public float bulletSpeed;
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        rigidB.AddForce(transform.up * bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemies enemy = FindObjectOfType<Enemies>();
        Oleadas waves = FindObjectOfType<Oleadas>();


        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2")
        {
            enemy.enemiesLifes--;
            if (enemy.enemiesLifes <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                waves.EnemyDestroyed(collision.gameObject.tag);
            }
            else if (enemy.enemiesLifes > 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "MiniBoss" || collision.gameObject.tag == "MiniBoss2")
        {
            enemy.miniBossLifes--;
            if (enemy.miniBossLifes <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                waves.EnemyDestroyed(collision.gameObject.tag);
            }
            else if (enemy.miniBossLifes > 0)
            {
                Destroy(gameObject);
            }

        }
        if (collision.gameObject.tag == "Boss")
        {
            enemy.bossLifes--;
            if (enemy.bossLifes <= 0)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
                waves.EnemyDestroyed(collision.gameObject.tag);
            }
            else if (enemy.bossLifes > 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
