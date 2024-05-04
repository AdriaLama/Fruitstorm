using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int punt;
    public TMP_Text puntuacion;
    public TMP_Text goldEarnedVictory;
    public TMP_Text goldEarnedDefeat;
    public int life;
    public TMP_Text lifes;
    //public TMP_Text timer;
    public float startingTime = 120f;
    public float currentTime = 120f;
    public GameObject areUReady;
    public GameObject Rifle;
    public GameObject Cesta;
    private GameManager Pausa;
    public List<int> collectedFrutas;
    public TMP_Text[] collectedFrutasText;
    public List<int> collectedFrutasDefeat;
    public TMP_Text[] collectedFrutasDefeatText;
    public AudioSource musica;
    public AudioClip MusicaJuego;
    public AudioClip MusicaJuegoRapida;
    public GameObject Sangre;
    public AudioClip Victory;
    public AudioClip Derrota;
    public AudioSource victoriaDerrota;
    private void Start()
    {
        
        
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
        //DisplayTime(currentTime);

        if (currentTime <= 0)
        {
            //timer.text = life.ToString();
            //timer.text = "00:00";
            PlayerPrefs.SetInt("gold", punt);
            PlayerPrefs.Save();
            Pausa.Victory();
            AudioSource.PlayClipAtPoint(Victory, transform.position);
            Sangre.SetActive(false);
            musica.Pause();
            Time.timeScale = 0f;
        }
        if (life <= 0)
        {
            life = 0;
            PlayerPrefs.SetInt("gold", punt);
            PlayerPrefs.Save();
            Pausa.Defeat();
            AudioSource.PlayClipAtPoint(Derrota, transform.position);
            Sangre.SetActive(false);
            musica.Pause();
        }

        puntuacion.text = punt.ToString();
        goldEarnedVictory.text = punt.ToString();
        goldEarnedDefeat.text = punt.ToString();
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
    /*void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/

   
}
