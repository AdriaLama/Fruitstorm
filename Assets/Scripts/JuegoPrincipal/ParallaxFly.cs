using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFly : MonoBehaviour
{
    public float speed;
    public float tileableZoneX;
    public float tileableZoneY;
    public float startingZoneX;
    public float startingZoneY;
    void Update()
    {
        Vector3 posicion = transform.position;

        if (posicion.x >= tileableZoneX)
        {

            posicion.x = startingZoneX;
            posicion.y = startingZoneY;

        }


        posicion.x += speed * Time.deltaTime;
        posicion.y += speed * Time.deltaTime;
        transform.position = posicion;
       
    }
}
