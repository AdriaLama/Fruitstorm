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
    public AudioSource armaSource;
    public AudioClip MusicaJuego;
    public CameraShake Camera;
    public GameObject MainCamera;
    public AudioSource musica;
    public AudioSource alienSound;
    

    private void Start()
    {
        
        Camera = GetComponent<CameraShake>();
    }

    void Update()
    {

        currTime += 1 * Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            armaSource.PlayOneShot(Arma);
            QuitarPowerUps();
            Rifle.SetActive(true);
            Cesta.SetActive(false);
            Alien.SetActive(true);
        }
        if (areUReady.activeInHierarchy)
        {
            Rifle.SetActive(false);
            Cesta.SetActive(true);
            musica.pitch = 1.3f;
            alienSound.Pause();
            StartCoroutine(QuitarMensaje(3f));
            CameraShake Camera = MainCamera.GetComponent<CameraShake>();
            StartCoroutine(Camera.Shake(20, 0.1f));
         
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
        SpawnPowerUp sp = FindObjectOfType<SpawnPowerUp>();
        sp.spawnTime = 7.5f;

    }

    public void QuitarPowerUps()
    {
        if (currTime <= 80)
        {
            SpawnPowerUp sp = FindObjectOfType<SpawnPowerUp>();
            sp.spawnTime = 100;

        }
        SpawnFrutas frenesi = FindObjectOfType<SpawnFrutas>();
        frenesi.spawnTime = 100f;
        SpawnBombas bomb = FindObjectOfType<SpawnBombas>();
        bomb.spawnTime = 100f;
    }
}
