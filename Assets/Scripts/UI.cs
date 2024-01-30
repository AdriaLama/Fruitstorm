using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text puntuacion;
    public TMP_Text lifes;
    public GameObject gameOver;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    void Update()
    {
        
    }
}
