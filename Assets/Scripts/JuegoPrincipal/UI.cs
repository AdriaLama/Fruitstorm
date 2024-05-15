using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public int punt;
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
    public List<int> collectedFrutas;
    public TMP_Text[] collectedFrutasText;
    public List<int> collectedFrutasDefeat;
    public TMP_Text[] collectedFrutasDefeatText;
    public AudioSource musica;
    public AudioClip MusicaJuego;
    public AudioClip MusicaJuegoRapida;
    public GameObject Sangre;
    public AudioClip Victoria;
    public AudioClip Derrota;
    public AudioSource victoriaDerrota;

    private void Start()
    {
        areUReady.SetActive(false);
        currentTime = startingTime;

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
        MenusGame menu = FindObjectOfType<MenusGame>();

        if (currentTime <= 0)
        {
            GameManager.Instance.gold += punt;
            punt = 0;
            menu.Victory();
            AudioSource.PlayClipAtPoint(Victoria, transform.position);
            Sangre.SetActive(false);
            musica.Pause();
            Time.timeScale = 0f;
        }
        if (life <= 0)
        {
            life = 0;
            GameManager.Instance.gold += punt;
            punt = 0;
            menu.Defeat();
            AudioSource.PlayClipAtPoint(Derrota, transform.position);
            Sangre.SetActive(false);
            musica.Pause();
        }

       
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
}
