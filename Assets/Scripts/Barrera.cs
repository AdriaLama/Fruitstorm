using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrera : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrera"))
        {
            // Desactivar la colisión con bombas
            DestroyBombs();
        }
    }
    private void DestroyBombs()
    {
        // Buscar y destruir todos los objetos con la etiqueta "Bomba"
        GameObject[] bombas = GameObject.FindGameObjectsWithTag("Bomba");
        foreach (GameObject bomba in bombas)
        {
            Destroy(bomba);
        }
    }

}
