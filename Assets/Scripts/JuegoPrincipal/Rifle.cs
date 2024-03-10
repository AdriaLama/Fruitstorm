using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public GameObject Bala;
    Collider2D coll;
    public GameObject RiflePersonaje;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        coll = GetComponent<Collider2D>();
        spriteRenderer = RiflePersonaje.GetComponent<SpriteRenderer>();

    }


    void Update()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        
        if (horizontalInput < 0)
        {
            spriteRenderer.flipY = true;
        }
        else if (horizontalInput > 0)
        {
           
            spriteRenderer.flipY = false;
        }
        if (Input.GetButtonDown("Jump") && coll.enabled && RiflePersonaje.activeSelf)
        {
            GameObject temp = Instantiate(Bala, transform.position, transform.rotation);
            Destroy(temp, 1);
        }

    }
}
