using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
 
    public float speed;
    private bool invertido = false;
   
    void Update()
    {
        float horizontal;
        if (invertido)
        {
            horizontal = Input.GetAxis("HorizontalInvertido");
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");
        }
        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

     
    }

    public void Invertido()
    {
        invertido = !invertido;
    }
}
