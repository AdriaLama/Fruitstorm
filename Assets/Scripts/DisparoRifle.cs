using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody2D rb;
    public float bullet_speed;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bullet_speed);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Alien")
        {
            Alien alienLifes = FindObjectOfType<Alien>();
            alienLifes.alienLifes--;
            
            if (alienLifes.alienLifes <= 0) {
                 Destroy(collision.gameObject);
                 Destroy(gameObject);
            }
            else if (alienLifes.alienLifes > 0)
            {
                Destroy(gameObject);
               
            }
            
        }
       
    }
}