using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
    public float speed;
    public float scaleX;
    public float scaleY;
    public float pos;
    private AudioSource audioSource;
    public AudioClip Mejoras;
    public int costSpace = 5000;
    public TMP_Text costSpaceText;
    public int costHeaven = 5000;
    public TMP_Text costHeavenText;
    public int costRevenge = 5000;
    public TMP_Text costRevengeText;
    public bool hasCrucifix = false;
    public bool hasSpaceSuit = false;
    public bool hasSpacecraft = false;

    public GameObject redButtonSpeed;
    public GameObject redButtonBasket;
    public GameObject redButtonCrucifix;
    public GameObject redButtonSpaceSuit;
    public GameObject redButtonSpacecraft;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        costSpeedTMP.text = costSpeed.ToString();
        levelSpeedTMP.text = levelSpeed.ToString();
        costBasketTMP.text = costBasket.ToString();
        levelBasketTMP.text = levelBasket.ToString();
        goldTMP.text = gold.ToString();
        costHeavenText.text = costHeaven.ToString();
        costSpaceText.text = costSpace.ToString();
        costRevengeText.text = costRevenge.ToString();

        if (GameManager.Instance != null)
        {
            gold = GameManager.Instance.gold;
            costSpeed = GameManager.Instance.costSpeed;
            levelSpeed = GameManager.Instance.levelSpeed;
            costBasket = GameManager.Instance.costBasket;
            levelBasket = GameManager.Instance.levelBasket;
            speed = GameManager.Instance.speed;
            scaleX = GameManager.Instance.basketScaleX;
            scaleY = GameManager.Instance.basketScaleY;
            pos = GameManager.Instance.basketPosY;
            hasCrucifix = GameManager.Instance.hasCrucifix;
            hasSpaceSuit = GameManager.Instance.hasSpaceSuit;
            hasSpacecraft = GameManager.Instance.hasSpacecraft;
        }

        if (gold >= costSpeed)
        {
            redButtonSpeed.SetActive(false);
        }
        else
        {
            redButtonSpeed.SetActive(true);
        }
        if (gold >= costBasket)
        {
            redButtonBasket.SetActive(false);
        }
        else
        {
            redButtonBasket.SetActive(true);
        }
        if (gold >= costHeaven)
        {
            redButtonCrucifix.SetActive(false);
        }
        else
        {
            redButtonCrucifix.SetActive(true);
        }
        if (gold >= costSpace)
        {
            redButtonSpaceSuit.SetActive(false);
        }
        else
        {
            redButtonSpaceSuit.SetActive(true);
        }
        if (gold >= costRevenge)
        {
            redButtonSpacecraft.SetActive(false);
        }
        else
        {
            redButtonSpacecraft.SetActive(true);
        }
    }

    public void LevelUpSpeed()
    {
        if (gold >= costSpeed)
        {
            audioSource.PlayOneShot(Mejoras);
            GameManager.Instance.speed += 1f;
            GameManager.Instance.levelSpeed++;
            GameManager.Instance.gold -= costSpeed;
            GameManager.Instance.costSpeed *= 5;
        }
    }

    public void LevelUpBasket()
    {
        if (gold >= costBasket)
        {
            audioSource.PlayOneShot(Mejoras);
            GameManager.Instance.basketScaleX += 0.1f;
            GameManager.Instance.basketScaleY += 0.1f;
            GameManager.Instance.basketPosY += 0.25f;
            GameManager.Instance.levelBasket++;
            GameManager.Instance.gold -= costBasket;
            GameManager.Instance.costBasket *= 5;
        }
    }

    public void BuyCrucifix()
    {
        if (gold >= costHeaven && !hasCrucifix)
        {
            GameManager.Instance.gold -= costHeaven;
            GameManager.Instance.hasCrucifix = true;
        }
    }

    public void BuySpaceSuit()
    {
        if (gold >= costSpace && !hasSpaceSuit) {
            GameManager.Instance.gold -= costSpace;
            GameManager.Instance.hasSpaceSuit = true;
        }
    }
    
    public void BuySpacecraft()
    {
        if (gold >= costRevenge && !hasSpacecraft)
        {
            GameManager.Instance.gold -= costRevenge;
            GameManager.Instance.hasSpacecraft = true;
        }
    }
}
