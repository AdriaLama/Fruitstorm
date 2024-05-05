using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    private float initialYPosition;
    public Transform startPoint; // Punto de inicio
    public Transform endPoint; // Punto final
    private Vector3 currentTarget; // Objetivo actual
    public GameObject LaserDisparo;
    public float intervaloDisparo = 3f;
    private bool hasStartedShooting = false;


    void Start()
    {
        currentTarget = endPoint.position;
        initialYPosition = transform.position.y;

    }
    void Update()
    {
      
        if (!hasStartedShooting)
        {
                InvokeRepeating("Disparar", 0f, intervaloDisparo);
                hasStartedShooting = true;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, endPoint.position) < 0.001f)
        {
            currentTarget = startPoint.position;
        }
        else if (Vector3.Distance(transform.position, startPoint.position) < 0.001f)
        {
            currentTarget = endPoint.position;
        }
    }
    void Disparar()
    {
        GameObject temp = Instantiate(LaserDisparo, transform.position, transform.rotation);
        Destroy(temp, 3);
    }
}
