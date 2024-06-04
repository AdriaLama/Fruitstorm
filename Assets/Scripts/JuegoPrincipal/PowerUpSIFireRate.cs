using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSIFireRate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           FireRate();
            Destroy(gameObject);
        }
    }

    private void FireRate()
    {
        DisparoNave movnav = FindObjectOfType<DisparoNave>();
        movnav.firerate -= 0.1f;
    }
}
