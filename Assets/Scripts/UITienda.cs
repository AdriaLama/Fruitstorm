using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.ShaderData;

public class UITienda : MonoBehaviour
{
    public int gold = 0;
    public TMP_Text goldTMP;
    public int costSpeed;
    public TMP_Text costSpeedTMP;
    public int levelSpeed;
    public TMP_Text levelSpeedTMP;
    public int costBasket;
    public TMP_Text costBasketTMP;
    public int levelBasket;
    public TMP_Text levelBasketTMP;
    void Update()
    {
        costSpeedTMP.text = costSpeed.ToString();
        levelSpeedTMP.text = levelSpeed.ToString();
        costBasketTMP.text = costBasket.ToString();
        levelBasketTMP.text = levelBasket.ToString();
        goldTMP.text = gold.ToString();
        UI ui = FindObjectOfType<UI>();
        gold = ui.finalPunt;

        for (levelSpeed = 1; levelSpeed <= 5; levelSpeed++)
        {
            costSpeed += 5000;
        }

        for (levelBasket = 1; levelBasket <= 5; levelBasket++)
        {
            costBasket += 5000;
        }
    }
}
