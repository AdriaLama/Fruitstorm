using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int punt;
    public TMP_Text puntuacion;
    public TMP_Text goldEarned;
    public TMP_Text goldEarnedDefeat;
    public int finalPunt;
    public TMP_Text finalGoldEarned;
    public int life;
    public TMP_Text lifes;
    public TMP_Text timer;
    public float startingTime = 120f;
    public float currentTime = 120f;
    public GameObject areUReady;
    public GameObject Rifle;
    public GameObject Cesta;
    private GameManager Pausa;
    public int remainingLifes;
    public TMP_Text remainingLifesTMP;
    public List<int> collectedFrutas;
    public TMP_Text[] collectedFrutasText;
    public List<int> collectedFrutasDefeat;
    public TMP_Text[] collectedFrutasDefeatText;
    private AudioSource audioSource;
    public AudioClip MusicaJuego;
    public AudioClip MusicaJuegoRapida;

    private void Awake()
    {
        finalPunt = 0;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        areUReady.SetActive(false);
        currentTime = startingTime;
        Pausa = FindObjectOfType<GameManager>();
        if (Pausa == null)
        {
            Debug.LogError("GameManager instance not found!");
        }

        collectedFrutas = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            collectedFrutas.Add(0);
        }

        collectedFrutasDefeat = new List<int>();
        for (int i = 0; i < 8; i++)
        {
            collectedFrutasDefeat.Add(0);
        }

    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        DisplayTime(currentTime);

        if (currentTime <= 0)
        {
            timer.text = life.ToString();
            timer.text = "00:00";
            currentTime = 0;
            remainingLifes = life;
            finalPunt = punt;
            PlayerPrefs.SetInt("gold", finalPunt);
            PlayerPrefs.Save();
            Pausa.Victory();
            audioSource.Pause();
            Time.timeScale = 0f;
        }
        if (life <= 0)
        {
            life = 0;
            finalPunt = punt;
            PlayerPrefs.SetInt("gold", finalPunt);
            PlayerPrefs.Save();
            Pausa.Defeat();
            audioSource.Pause();
        }

        puntuacion.text = punt.ToString();
        goldEarned.text = punt.ToString();
        goldEarnedDefeat.text = punt.ToString();
        finalGoldEarned.text = finalPunt.ToString();
        remainingLifesTMP.text = remainingLifes.ToString();
        lifes.text = life.ToString();

        for (int i = 0; i < collectedFrutasText.Length; i++)
        {
            collectedFrutasText[i].text = collectedFrutas[i].ToString();
        }

        for (int i = 0; i < collectedFrutasDefeatText.Length; i++)
        {
            collectedFrutasDefeatText[i].text = collectedFrutasDefeat[i].ToString();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

   
}
