using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
 
    public float speed;

    Vector2 vector;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

    }
}
