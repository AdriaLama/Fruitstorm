using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private float tiempoRestante, fuerzaShake, tiempo, rotacion;
    public float cantidadRotacion;
    public float cantidadFuerza;

    private Vector3 posIni;
    private bool shake;

    public static CameraShake instance;
    void Start()
    {
        instance = this;
        shake = false;
    }

    void LateUpdate()
    {
        if(shake)
        {
            if(tiempoRestante > 0f)
            {
                tiempoRestante -= Time.deltaTime;
                float cantidadX = posIni.x + Random.Range(-cantidadFuerza, cantidadFuerza) * fuerzaShake;
                float cantidadY = posIni.y + Random.Range(-cantidadFuerza, cantidadFuerza) * fuerzaShake;
                cantidadX = Mathf.MoveTowards(cantidadX, posIni.x, tiempo * Time.deltaTime);
                cantidadY = Mathf.MoveTowards(cantidadY, posIni.x, tiempo * Time.deltaTime);
                transform.position = new Vector3(cantidadX, cantidadY, posIni.z);

                rotacion = Mathf.MoveTowards(rotacion, 0f, tiempo * cantidadRotacion * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0f, 0f, rotacion * Random.Range(-1f, 1f));
            } else
            {
                transform.position = posIni;
                shake = false;
            }
        }
    }

    public void StartShake(float duration, float fuerza)
    {
        posIni = transform.position;
        shake = true;
        tiempoRestante = duration;
        fuerzaShake = fuerza;
        tiempo = fuerza / duration;
        rotacion = fuerza * cantidadRotacion;
    }
}
