using UnityEngine;
using TMPro;

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
        if (!PlayerPrefs.HasKey("levelSpeed"))
        {
            levelSpeed = 1;
            PlayerPrefs.SetInt("levelSpeed", levelSpeed);
        }
        if (!PlayerPrefs.HasKey("costSpeed"))
        {
            costSpeed = 5000;
            PlayerPrefs.SetInt("costSpeed", costSpeed);
        }
        if (!PlayerPrefs.HasKey("levelBasket"))
        {
            levelBasket = 1;
            PlayerPrefs.SetInt("levelBasket", levelBasket);
        }
        if (!PlayerPrefs.HasKey("costBasket"))
        {
            costBasket = 5000;
            PlayerPrefs.SetInt("costBasket", costBasket);
        }
        /*levelSpeed = 1;
        PlayerPrefs.SetInt("levelSpeed", levelSpeed);
        PlayerPrefs.Save();*/
        levelSpeed = PlayerPrefs.GetInt("levelSpeed");
        /*costSpeed = 5000;
        PlayerPrefs.SetInt("costSpeed", costSpeed);
        PlayerPrefs.Save();*/
        costSpeed = PlayerPrefs.GetInt("costSpeed");
        /*levelBasket = 1;
        PlayerPrefs.SetInt("levelBasket", levelBasket);
        PlayerPrefs.Save();*/
        levelBasket = PlayerPrefs.GetInt("levelBasket");
        /*costBasket = 5000;
        PlayerPrefs.SetInt("costBasket", costBasket);
        PlayerPrefs.Save();*/
        costBasket = PlayerPrefs.GetInt("costBasket");
    }

    public void LevelUpSpeed()
    {
        if (totalGold >= costSpeed)
        {
            speed += 1f;
            //speed = 10f;
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
        if (totalGold >= costBasket)
        {

            levelBasket++;
            PlayerPrefs.SetInt("levelBasket", levelBasket);
            PlayerPrefs.Save();
            totalGold -= costBasket;
            totalGoldSpent += costBasket;
            PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
            PlayerPrefs.Save();
            costBasket += 5000;
            PlayerPrefs.SetInt("costSpeed", costBasket);
            PlayerPrefs.Save();
        }
    }
}
