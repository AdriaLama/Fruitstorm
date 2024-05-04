using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRecolecta : MonoBehaviour
{
    public float speed;
    private bool movingRight = true;
    private float tempMovimiento;
    public float LimiteAlienPos;
    public float LimiteAlienNeg;
    public float alienLifes;
    public GameObject posMedio;
    
    

    void Start()
    {
        tempMovimiento = Random.Range(0.5f, 2f);
        LimiteAlienNeg = -100;
    }

    void Update()
    {


        tempMovimiento -= Time.deltaTime;
        Vector3 posicion = transform.position;


        if (tempMovimiento <= 0 || posicion.x > LimiteAlienPos || posicion.x < LimiteAlienNeg)
        {
            movingRight = !movingRight;
            tempMovimiento = Random.Range(0.5f, 2f);
        }


        if (movingRight)
        {
            posicion.x += speed * Time.deltaTime;
        }
        else
        {
            posicion.x -= speed * Time.deltaTime;

        }

        transform.position = posicion;

        if (posicion.x == posMedio.transform.position.x)
        {
            LimiteAlienNeg = -10.1f;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Destroy(collision.gameObject);
        }
    }


}