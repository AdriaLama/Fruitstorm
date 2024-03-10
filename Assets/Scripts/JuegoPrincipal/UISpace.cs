using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISpace : MonoBehaviour
{
    public int life;
    public TMP_Text lifes;
    private GameManager Pausa;

    void Update()
    {
        Pausa = FindObjectOfType<GameManager>();
        if (Pausa == null)
        {
            Debug.LogError("GameManager instance not found!");
        }
        Oleadas waves = FindObjectOfType<Oleadas>();

        lifes.text = life.ToString();


        if (life <= 0)
        {
            life = 0;
            Pausa.Defeat();
        }

        if (!waves.PrimeraOleada.activeSelf && !waves.SegundaOleada.activeSelf && !waves.UltimaOleada.activeSelf)
        {

            Pausa.Victory();
        }
    }


}
