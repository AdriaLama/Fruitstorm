using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesMapa : MonoBehaviour
{
    public float limiteXnegativo;
    public float limiteXpositivo;

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
    }


}

