using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
 
    public float speed;
    public float horizontal;

    Vector2 vector;
    public bool invertirControles = false;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

    }

    public void Invertido()
    {

        horizontal = -horizontal;


    }
}
