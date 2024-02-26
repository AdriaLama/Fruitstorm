using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyBombs : MonoBehaviour
{

    public GameObject Barrera;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomba"))
        {
            if (Barrera.activeSelf)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
