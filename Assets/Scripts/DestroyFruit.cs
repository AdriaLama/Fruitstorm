using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    public UI punt;
    public List<ConfiguracionFruta> configuracionFrutas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Destroy(collision.gameObject);
        }
    } 
}
