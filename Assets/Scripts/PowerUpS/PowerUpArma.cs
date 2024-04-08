using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArma : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Cesta;
    public GameObject Alien;
    public float currTime;
    public float spawnTime;
    public AudioClip Arma;

    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            AudioSource.PlayClipAtPoint(Arma, transform.position);
            SpawnFrutas frenesi = FindObjectOfType<SpawnFrutas>();
            frenesi.spawnTime = 100f;
            SpawnBombas bomb = FindObjectOfType<SpawnBombas>();
            bomb.spawnTime = 100f;
            Rifle.SetActive(true);
            Cesta.SetActive(false);
            Alien.SetActive(true);
        }
    }
}
