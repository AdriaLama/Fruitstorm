using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxClouds : MonoBehaviour
{
    public float speed;
    public float tileableZone;
    public float startingZone;
    void Update()
    {
        Vector3 posicion = transform.position;

        if (posicion.x > tileableZone)
        {
            posicion.x = startingZone;
        }

        posicion.x += speed * Time.deltaTime;
        transform.position = posicion;
    }
}
