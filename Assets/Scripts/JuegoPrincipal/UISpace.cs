using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISpace : MonoBehaviour
{
    public int life;
    public TMP_Text lifes;
    void Update()
    {
        Oleadas waves = FindObjectOfType<Oleadas>();
        MenusGame menu = FindObjectOfType<MenusGame>();

        lifes.text = life.ToString();


        if (life <= 0)
        {
            life = 0;
            menu.Defeat();
        }

        if (!waves.PrimeraOleada.activeSelf && !waves.SegundaOleada.activeSelf && !waves.UltimaOleada.activeSelf)
        {

            menu.Victory();
        }
    }


}
