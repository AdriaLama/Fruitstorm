using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public int punt;
    public TMP_Text puntuacion;
    public int life;
    public TMP_Text lifes;
    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }



    void Update()
    {
        puntuacion.text = punt.ToString();
        lifes.text = life.ToString();
        if (punt >= 100)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        if (life >= 10)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
