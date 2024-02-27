using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int punt;
    public TMP_Text puntuacion;
    public int life;
    public TMP_Text lifes;
    public TMP_Text timer;
    private float startingTime = 120f;
    float currentTime = 0f;
    bool timerIsActive = true;
    public GameObject gameOver;
    public GameObject victory;
    public GameObject areUReady;
    public GameObject Rifle;
    public GameObject Pausa;


    private void Start()
    {
        gameOver.SetActive(false);
        victory.SetActive(false);
        areUReady.SetActive(false);
        currentTime = startingTime;
    }



    void Update()
    {
        puntuacion.text = punt.ToString();
        lifes.text = life.ToString();
        if (punt >= 2000)
        {
            punt = 2000;
            victory.SetActive(true);
            Time.timeScale = 0;
        }

        if (life <= 0)
        {
            life = 0;
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        if (timerIsActive)
        {
            currentTime -= 1 * Time.deltaTime;
            DisplayTime(currentTime);
        }

        if (currentTime <= 0)
        {
            timer.text = life.ToString();
            timer.text = "00:00";
            currentTime = 0;
            timerIsActive = false;
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if (areUReady.activeSelf) {
            StartCoroutine(QuitarMensaje(3f));
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public IEnumerator QuitarMensaje(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        areUReady.SetActive(false);
        SpawnFrutas frenesi = FindObjectOfType<SpawnFrutas>();
        frenesi.spawnTime = 0.15f;
        Rifle.SetActive(false);
    }
}
