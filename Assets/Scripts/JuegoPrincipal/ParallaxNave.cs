using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxNave : MonoBehaviour
{
    public Transform startPoint; // Punto de inicio
    public Transform endPoint; // Punto final
    public float speed = 2f; // Velocidad de movimiento
    private SpriteRenderer spriteRenderer;

    private Vector3 currentTarget; // Objetivo actual

    void Start()
    {
        // Comenzamos moviendo hacia el punto final
        currentTarget = endPoint.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movimiento suave entre los puntos de inicio y final
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Si alcanzamos el punto final, cambiamos al punto de inicio
        if (Vector3.Distance(transform.position, endPoint.position) < 0.001f)
        {
            currentTarget = startPoint.position;
            spriteRenderer.flipX = true;
        }
        // Si alcanzamos el punto de inicio, cambiamos al punto final
        else if (Vector3.Distance(transform.position, startPoint.position) < 0.001f)
        {
            currentTarget = endPoint.position;
            spriteRenderer.flipX = false;
        }
    }
}