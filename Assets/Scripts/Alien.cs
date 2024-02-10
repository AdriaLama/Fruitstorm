using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed;
    public float LimiteAlienPos;
    public float LimiteAlienNeg;
    private bool movingRight = true;

    void Update()
    {
        Vector3 posicion = transform.position;

        if (movingRight)
        {
            posicion.x += speed * Time.deltaTime;
            if (posicion.x > LimiteAlienPos)
            {
                movingRight = false;
            }
        }
        else
        {
            posicion.x -= speed * Time.deltaTime;
            if (posicion.x < LimiteAlienNeg)
            {
                movingRight = true;
            }
        }

        transform.position = posicion;
    }
}
