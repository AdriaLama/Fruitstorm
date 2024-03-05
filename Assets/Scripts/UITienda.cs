using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.ShaderData;

public class UITienda : MonoBehaviour
{
    public int gold;
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
    }

    void Update()
    {
        costSpeedTMP.text = costSpeed.ToString();
        levelSpeedTMP.text = levelSpeed.ToString();
        costBasketTMP.text = costBasket.ToString();
        levelBasketTMP.text = levelBasket.ToString();
        goldTMP.text = gold.ToString();
    }

    public void LevelUpSpeed()
    {
        if (gold >= costSpeed)
        {
            speed *= 1.25f;
            PlayerPrefs.SetFloat("speedlvlup", speed);
            PlayerPrefs.Save();
            levelSpeed++;
            gold -= costSpeed;
            costSpeed += 5000;
        }
    }

    public void LevelUpBasket()
    {

    }
}
