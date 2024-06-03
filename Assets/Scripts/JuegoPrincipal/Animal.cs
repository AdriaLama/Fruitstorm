using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float speedVaca;
    private bool moveRight = true;
    private float vacaMovimiento;
    public float LimiteVacaPos;
    public float LimiteVacaNeg;
    private SpriteRenderer sprite;
    public GameObject vaca;


    void Start()
    {
        vacaMovimiento = Random.Range(0.5f, 2f);
        sprite = vaca.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        vacaMovimiento -= Time.deltaTime;
        Vector3 posicion = transform.position;


        if (vacaMovimiento <= 0 || posicion.x > LimiteVacaPos || posicion.x < LimiteVacaNeg)
        {
            moveRight = !moveRight;
            vacaMovimiento = Random.Range(0.5f, 2f);
        }


        if (moveRight)
        {
            posicion.x += speedVaca * Time.deltaTime;
            sprite.flipX = false;
        }
        else
        {
            posicion.x -= speedVaca * Time.deltaTime;
            sprite.flipX = true;

        }

        transform.position = posicion;

        
    }
}
