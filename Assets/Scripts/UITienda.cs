using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.ShaderData;

public class UITienda : MonoBehaviour
{
    public int gold;
    public int totalGold = 0;
    public int totalGoldSpeed = 0;
    public bool hasBought = false;
    public TMP_Text goldTMP;
    public int costSpeed = 5000;
    public TMP_Text costSpeedTMP;
    public int levelSpeed = 1;
    public TMP_Text levelSpeedTMP;
    public int costBasket = 5000;
    public TMP_Text costBasketTMP;
    public int levelBasket = 1;
    public TMP_Text levelBasketTMP;
    private float speed;

    void Awake()
    {
        speed = PlayerPrefs.GetFloat("speed");
        gold = PlayerPrefs.GetInt("gold");
        totalGold = PlayerPrefs.GetInt("totalGold");
        totalGoldSpeed = PlayerPrefs.GetInt("totalGoldPay");
        ActualizarOro();
    }

    void Update()
    {
        costSpeedTMP.text = costSpeed.ToString();
        levelSpeedTMP.text = levelSpeed.ToString();
        costBasketTMP.text = costBasket.ToString();
        levelBasketTMP.text = levelBasket.ToString();
        goldTMP.text = totalGold.ToString();

        if (!hasBought)
        {
            totalGoldSpeed = 0;
        }
    }

    public void ActualizarOro()
    {
        totalGold += gold;

        if (hasBought)
        {
            totalGold -= totalGoldSpeed;
            totalGoldSpeed = 0;
        }

        PlayerPrefs.SetInt("totalGold", totalGold);
        PlayerPrefs.Save();
    }
    

public void LevelUpSpeed()
    {
        if (totalGold >= costSpeed)
        {
            hasBought = true;
            speed *= 1.25f;
            PlayerPrefs.SetFloat("speedlvlup", speed);
            PlayerPrefs.Save();
            levelSpeed++;
            totalGold -= costSpeed;
            totalGoldSpeed += costSpeed;
            PlayerPrefs.SetInt("totalGoldSpeed", totalGoldSpeed);
            PlayerPrefs.Save();
            costSpeed += 5000;
        }
        else
        {
            hasBought = false;
        }
    }

    public void LevelUpBasket()
    {

    }
}
