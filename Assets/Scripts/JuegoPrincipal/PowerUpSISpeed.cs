using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpSISpeed : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            SpeedNave();
            Destroy(gameObject);
        }
    }

    private void SpeedNave()
    {
        MovimientoNave movnav = FindObjectOfType<MovimientoNave>();
        movnav.speed += 1f;
    }

}
