using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public GameObject Bala;
    Collider2D coll;
    public GameObject RiflePersonaje;
    

    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && coll.enabled && RiflePersonaje.activeSelf)
        {
            GameObject temp = Instantiate(Bala, transform.position, transform.rotation);
            Destroy(temp, 1);
        }
    }
}
