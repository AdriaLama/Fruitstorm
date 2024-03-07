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
    private float startingTime = 121f;
    float currentTime = 0f;
    bool timerIsActive = true;
    public GameObject areUReady;
    public GameObject Rifle;
    public GameObject Cesta;
    private GameManager Pausa;
    public int secondsRemaining;
    public TMP_Text secondsRemainingTMP;
    public List<int> collectedFrutas;
    public TMP_Text[] collectedFrutasText;
    public List<int> collectedFrutasDefeat;
    public TMP_Text[] collectedFrutasDefeatText;

    private void Awake()
    {
        finalPunt = 0;
    }
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
        puntuacion.text = punt.ToString();
        goldEarned.text = punt.ToString();
        goldEarnedDefeat.text = punt.ToString();
        finalGoldEarned.text = finalPunt.ToString();
        secondsRemainingTMP.text = secondsRemaining.ToString();
        lifes.text = life.ToString();

        for (int i = 0; i < collectedFrutasText.Length; i++)
        {
            collectedFrutasText[i].text = collectedFrutas[i].ToString();
        }

        for (int i = 0; i < collectedFrutasDefeatText.Length; i++)
        {
            collectedFrutasDefeatText[i].text = collectedFrutasDefeat[i].ToString();
        }

        if (punt >= 2000)
        {
            punt = 2000;
            finalPunt = punt * life;
            PlayerPrefs.SetInt("gold", finalPunt);
            PlayerPrefs.Save();
            Pausa.Victory();
        }

        if (life <= 0)
        {
            life = 0;
            finalPunt = punt;
            PlayerPrefs.SetInt("gold", finalPunt);
            PlayerPrefs.Save();
            Pausa.Defeat();
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
            finalPunt = punt;
            PlayerPrefs.SetInt("gold", finalPunt);
            PlayerPrefs.Save();
            Pausa.Defeat();
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
        Cesta.SetActive(true);
    }
}
