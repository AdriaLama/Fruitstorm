using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleadas : MonoBehaviour
{
    public GameObject PrimeraOleada;
    public GameObject SegundaOleada;
    public GameObject UltimaOleada;

    private int remainingEnemiesInFirstWave;
    private int remainingEnemiesInSecondWave;

    void Start()
    {
        remainingEnemiesInFirstWave = GameObject.FindGameObjectsWithTag("Enemy").Length +
        GameObject.FindGameObjectsWithTag("MiniBoss").Length;

        SegundaOleada.SetActive(false);
    }

    void Update()
    {
        if (remainingEnemiesInFirstWave == 0)
        {
            SegundaOleada.SetActive(true);
            remainingEnemiesInSecondWave = GameObject.FindGameObjectsWithTag("Enemy2").Length +
            GameObject.FindGameObjectsWithTag("MiniBoss2").Length;
        }

        if (remainingEnemiesInFirstWave == 0 && remainingEnemiesInSecondWave == 0)
        {
            SegundaOleada.SetActive(false);
            UltimaOleada.SetActive(true);
        }
    }

    public void EnemyDestroyed(string enemyTag)
    {
        if (enemyTag == "Enemy" || enemyTag == "MiniBoss")
        {
            remainingEnemiesInFirstWave--;
        }
        else if (enemyTag == "Enemy2" || enemyTag == "MiniBoss2")
        {
            remainingEnemiesInSecondWave--;
        }
    }
}
