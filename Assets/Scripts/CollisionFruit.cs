using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oll : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Destroy(collision.gameObject, 2);
        }
    }
}
