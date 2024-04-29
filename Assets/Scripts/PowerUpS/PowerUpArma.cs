using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpArma : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Cesta;
    public GameObject Alien;
    public GameObject areUReady;
    public float currTime;
    public float spawnTime;
    public AudioClip Arma;
    public AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            myAudioSource.PlayOneShot(Arma);
            SpawnFrutas frenesi = FindObjectOfType<SpawnFrutas>();
            frenesi.spawnTime = 100f;
            SpawnBombas bomb = FindObjectOfType<SpawnBombas>();
            bomb.spawnTime = 100f;
            Rifle.SetActive(true);
            Cesta.SetActive(false);
            Alien.SetActive(true);
        }
        if (areUReady.activeInHierarchy)
        {
            Rifle.SetActive(false);
            Cesta.SetActive(true);
            StartCoroutine(QuitarMensaje(3f));
        }
    }
    public IEnumerator QuitarMensaje(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        areUReady.SetActive(false);
        SpawnFrutas frenesi = FindObjectOfType<SpawnFrutas>();
        frenesi.spawnTime = 0.15f;
        SpawnBombas bomb = FindObjectOfType<SpawnBombas>();
        bomb.spawnTime = 1f;
    }
}
