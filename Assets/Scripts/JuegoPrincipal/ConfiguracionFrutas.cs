using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ConfiguracionFruta", menuName = "Configuraciones/ConfiguracionFruta")]
public class ConfiguracionFruta : ScriptableObject
{
    public Sprite sprite;
    public float velocidad;
    public float gold;
    public Collider2D collider;
}


