using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionNave : MonoBehaviour
{
    public float limiteXnegativo;
    public float limiteYnegativo;
    public float limiteXpositivo;
    public float limiteYpositivo;

    void Update()
    {
        if (limiteXpositivo < transform.position.x)
        {
            transform.position = new Vector3(limiteXpositivo, transform.position.y, 0);
        }
        if (limiteXnegativo > transform.position.x)
        {
            transform.position = new Vector3(limiteXnegativo, transform.position.y, 0);
        }
        if (limiteYpositivo < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, limiteYpositivo, 0);
        }
        if (limiteYnegativo > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, limiteYnegativo, 0);
        }
    }
}
