using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSILife : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeUp();
            Destroy(gameObject);
        }
    }

    private void LifeUp()
    {
        UISpace movnav = FindObjectOfType<UISpace>();
        movnav.life += 10;
    }

}
