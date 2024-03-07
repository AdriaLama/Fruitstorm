using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.ShaderData;
using UnityEngine.UI;

public class UITienda : MonoBehaviour
{
    public int gold;
    public int totalGold = 0;
    public int totalGoldSpent = 0;
    public TMP_Text goldTMP;
    public int costSpeed = 5000;
    public TMP_Text costSpeedTMP;
    public int levelSpeed = 1;
    public TMP_Text levelSpeedTMP;
    public int costBasket = 5000;
    public TMP_Text costBasketTMP;
    public int levelBasket = 1;
    public TMP_Text levelBasketTMP;
    public float speed;

    void Awake()
    {
        gold = PlayerPrefs.GetInt("gold");
        totalGold = PlayerPrefs.GetInt("totalGold");
        totalGoldSpent = PlayerPrefs.GetInt("totalGoldSpent");
        speed = PlayerPrefs.GetFloat("speed");
        ActualizarOro();
        ActualizarTienda();
    }

    void Update()
    {
        costSpeedTMP.text = costSpeed.ToString();
        levelSpeedTMP.text = levelSpeed.ToString();
        costBasketTMP.text = costBasket.ToString();
        levelBasketTMP.text = levelBasket.ToString();
        goldTMP.text = totalGold.ToString();
    }

    public void ActualizarOro()
    {
        totalGold += gold;

        totalGoldSpent = PlayerPrefs.GetInt("totalGoldSpent");

        totalGold -= totalGoldSpent;
        totalGoldSpent = 0;
        PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
        PlayerPrefs.Save();

        //totalGold = 0;
        PlayerPrefs.SetInt("totalGold", totalGold);
        PlayerPrefs.Save();
    }

    public void ActualizarTienda()
    {
        /*levelSpeed = 1;
        PlayerPrefs.SetInt("levelSpeed", levelSpeed);
        PlayerPrefs.Save();*/
        levelSpeed = PlayerPrefs.GetInt("levelSpeed");
        /*costSpeed = 5000;
        PlayerPrefs.SetInt("costSpeed", costSpeed);
        PlayerPrefs.Save();*/
        costSpeed = PlayerPrefs.GetInt("costSpeed");
    }

    public void LevelUpSpeed()
    {
        if (totalGold >= costSpeed)
        {
            speed *= 1.5f;
            PlayerPrefs.SetFloat("speed", speed);
            PlayerPrefs.SetFloat("speedlvlup", speed);
            PlayerPrefs.Save();
            levelSpeed++;
            PlayerPrefs.SetInt("levelSpeed", levelSpeed);
            PlayerPrefs.Save();
            totalGold -= costSpeed;
            totalGoldSpent += costSpeed;
            PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
            PlayerPrefs.Save();
            costSpeed += 5000;
            PlayerPrefs.SetInt("costSpeed", costSpeed);
            PlayerPrefs.Save();
        }
    }

    public void LevelUpBasket()
    {

    }
}
