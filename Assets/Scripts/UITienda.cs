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
    public int initialLevelSpeed = 0;

    void Awake()
    {
        speed = PlayerPrefs.GetFloat("speed");
        gold = PlayerPrefs.GetInt("gold");
        totalGold = PlayerPrefs.GetInt("totalGold");
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

        if (initialLevelSpeed >= levelSpeed)
        {
            totalGoldSpeed = PlayerPrefs.GetInt("totalGoldPay");
        }
        else
        {
            totalGoldSpeed = 0;
            PlayerPrefs.SetInt("DontPay", totalGoldSpeed);
            PlayerPrefs.Save();
            totalGoldSpeed = PlayerPrefs.GetInt("DontPay");
        }

        totalGold -= totalGoldSpeed;
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
            speed *= 1.25f;
            PlayerPrefs.SetFloat("speedlvlup", speed);
            PlayerPrefs.Save();
            initialLevelSpeed++;
            levelSpeed++;
            PlayerPrefs.SetInt("levelSpeed", levelSpeed);
            PlayerPrefs.Save();
            totalGold -= costSpeed;
            totalGoldSpeed += costSpeed;
            PlayerPrefs.SetInt("totalGoldPay", totalGoldSpeed);
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
