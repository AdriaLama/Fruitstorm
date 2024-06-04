using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oleadas : MonoBehaviour
{
    public GameObject PrimeraOleada;
    public GameObject SegundaOleada;
    public GameObject UltimaOleada;

    public GameObject AnimBomba;
    public AudioSource destroy;


    private int remainingEnemiesInFirstWave;
    private int remainingEnemiesInSecondWave;
    private int remainingEnemiesInThirdWave;
    void Start()
    {

        remainingEnemiesInFirstWave = GameObject.FindGameObjectsWithTag("Enemy").Length +
        GameObject.FindGameObjectsWithTag("MiniBoss").Length;

        SegundaOleada.SetActive(false);
    }

    private T FindAnyObjectOfType<T>()
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        if (remainingEnemiesInFirstWave == 0)
        {
            PrimeraOleada.SetActive(false);
            SegundaOleada.SetActive(true);
            remainingEnemiesInSecondWave = GameObject.FindGameObjectsWithTag("Enemy2").Length +
            GameObject.FindGameObjectsWithTag("MiniBoss2").Length;
        }

        if (remainingEnemiesInFirstWave == 0 && remainingEnemiesInSecondWave == 0)
        {
            SegundaOleada.SetActive(false);
            UltimaOleada.SetActive(true);
            remainingEnemiesInThirdWave = GameObject.FindGameObjectsWithTag("Boss").Length +
            GameObject.FindGameObjectsWithTag("MiniBoss2").Length;
        }

        if (remainingEnemiesInFirstWave == 0 && remainingEnemiesInSecondWave == 0 && remainingEnemiesInThirdWave == 0)
        {
            UltimaOleada.SetActive(false);
        }
    }

    public void EnemyDestroyed(GameObject enemy)
    {
        GameObject temp = Instantiate(AnimBomba, new Vector2(enemy.transform.position.x, enemy.transform.position.y), enemy.transform.rotation);

        string enemyTag = enemy.tag;
        if (enemyTag == "Enemy" || enemyTag == "MiniBoss")
        {
            destroy.Play();
            Destroy(temp, 0.15f);
            remainingEnemiesInFirstWave--;
            DropPowerUp(enemy); 
        }
        else if (enemyTag == "Enemy2" || enemyTag == "MiniBoss2")
        {
            destroy.Play();
            Destroy(temp, 0.15f);
            remainingEnemiesInSecondWave--;
            DropPowerUp(enemy);
        }
        else if(enemyTag == "MiniBoss2" || enemyTag == "Boss")
        {
            destroy.Play();
            Destroy(temp, 0.15f);
            remainingEnemiesInThirdWave--;
            DropPowerUp(enemy);

        }
    }
    private void DropPowerUp(GameObject enemy)
    {
        Enemies enemyComponent = enemy.GetComponent<Enemies>();
        if (enemyComponent != null)
        {
            enemyComponent.DropPowerUp();
        }
    }
}
