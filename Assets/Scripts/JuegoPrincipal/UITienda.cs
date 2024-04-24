using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
    public float scaleX;
    public float scaleY;
    public float pos;
    private AudioSource audioSource;
    public AudioClip Mejoras;
    public int costSpace = 1000;
    public TMP_Text costSpaceText;
    public int costHeaven = 1000;
    public TMP_Text costHeavenText;
    public int costRevenge = 1000;
    public TMP_Text costRevengeText;
    public GameObject OuterSpace;
    public GameObject Heaven;
    

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gold = PlayerPrefs.GetInt("gold");
        totalGold = PlayerPrefs.GetInt("totalGold");
        totalGoldSpent = PlayerPrefs.GetInt("totalGoldSpent");
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
     
        if (!PlayerPrefs.HasKey("speedlvlup"))
        {
            speed = 10;
            PlayerPrefs.SetFloat("speedlvlup", speed);
        }
        if (!PlayerPrefs.HasKey("newScaleX"))
        {
            scaleX = 0.8f;
            PlayerPrefs.SetFloat("newScaleX", scaleX);
        }
        if (!PlayerPrefs.HasKey("newScaleY"))
        {
            scaleY = 0.8f;
            PlayerPrefs.SetFloat("newScaleY", scaleY);
        }
        if (!PlayerPrefs.HasKey("newPos"))
        {
            pos = 10.5f;
            PlayerPrefs.SetFloat("newPos", pos);
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
        /*speed = 10f;
        PlayerPrefs.SetFloat("speedlvlup", speed);
        PlayerPrefs.Save();
        speed = PlayerPrefs.GetFloat("speedlvlup");*/
        speed = PlayerPrefs.GetFloat("speed");
        /*scaleX = 0.8f;
        PlayerPrefs.SetFloat("newScaleX", scaleX);
        PlayerPrefs.Save();
        scaleX = PlayerPrefs.GetFloat("newScaleX");*/
        scaleX = PlayerPrefs.GetFloat("scaleX");
        /*scaleY = 0.8f;
        PlayerPrefs.SetFloat("newScaleY", scaleY);
        PlayerPrefs.Save();
        scaleY = PlayerPrefs.GetFloat("newScaleY");*/
        scaleY = PlayerPrefs.GetFloat("scaleY");
        /*pos = 10.5f;
        PlayerPrefs.SetFloat("newPos", pos);
        PlayerPrefs.Save();
        pos = PlayerPrefs.GetFloat("newPos");*/
        pos = PlayerPrefs.GetFloat("pos");
    }

    public void LevelUpSpeed()
    {
        if (totalGold >= costSpeed)
        {
            audioSource.PlayOneShot(Mejoras);
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
            audioSource.PlayOneShot(Mejoras);
            scaleX += 0.1f;
            scaleY += 0.1f;
            pos += 0.25f;
            //scaleX = 0.8f;
            //scaleY = 0.8f;
            //pos = 10.5f;
            PlayerPrefs.SetFloat("newScaleX", scaleX);
            PlayerPrefs.Save();
            PlayerPrefs.SetFloat("newScaleY", scaleY);
            PlayerPrefs.Save();
            PlayerPrefs.SetFloat("newPos", pos);
            PlayerPrefs.Save();
            levelBasket++;
            PlayerPrefs.SetInt("levelBasket", levelBasket);
            PlayerPrefs.Save();
            totalGold -= costBasket;
            totalGoldSpent += costBasket;
            PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
            PlayerPrefs.Save();
            costBasket += 5000;
            PlayerPrefs.SetInt("costBasket", costBasket);
            PlayerPrefs.Save();
        }
    }

    public void GoSpace()
    {
        if (totalGold >= costSpace) { 
            totalGold -= costSpace;
            totalGoldSpent += costSpace;
            PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
            PlayerPrefs.Save();
            gold = 0;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuEspacio");
        }

    }
    public void GoHeaven()
    {
        if (totalGold >= costHeaven)
        {
            totalGold -= costHeaven;
            totalGoldSpent += costHeaven;
            PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
            PlayerPrefs.Save();
            gold = 0;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("MenuCielo");
        }

    }


    public void Revenge()
    {
        if (totalGold >= costRevenge)
        {
            totalGold -= costRevenge;
            totalGoldSpent += costRevenge;
            PlayerPrefs.SetInt("totalGoldSpent", totalGoldSpent);
            PlayerPrefs.Save();
            gold = 0;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("SpaceInvaders");
        }
    }
}
