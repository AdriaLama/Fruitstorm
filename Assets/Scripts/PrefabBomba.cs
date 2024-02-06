using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabBomba : MonoBehaviour
{
    public float speed;
    public void SpawnBomba() { 
        Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(0, -speed);
    }
}
