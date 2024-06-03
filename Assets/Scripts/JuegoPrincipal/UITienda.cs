using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UITienda : MonoBehaviour
{
    public int gold;
    public TMP_Text goldTMP;
    public int costSpeed;
    public TMP_Text costSpeedTMP;
    public TMP_Text costSpeedRed;
    public int levelSpeed;
    public TMP_Text levelSpeedTMP;
    public int costBasket;
    public TMP_Text costBasketTMP;
    public TMP_Text costBasketRed;
    public int levelBasket;
    public TMP_Text levelBasketTMP;
    public float speed;
    public float scaleX;
    public float scaleY;
    public float pos;
    private AudioSource audioSource;
    public AudioClip Mejoras;
    public GameObject Crucifix;
    public GameObject SpaceSuit;
    public GameObject Spaceship;
    public int costHeaven;
    public TMP_Text costHeavenText;
    public TMP_Text costHeavenRed;
    public int costSpace;
    public TMP_Text costSpaceText;
    public TMP_Text costSpaceRed;
    public int costRevenge;
    public TMP_Text costRevengeText;
    public TMP_Text costRevengeRed;
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

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MenuPrincipal" || SceneManager.GetActiveScene().name == "Juego")
        {
            Crucifix.SetActive(true);
            SpaceSuit.SetActive(false);
            Spaceship.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "MenuCielo" || SceneManager.GetActiveScene().name == "Cielo")
        {
            Crucifix.SetActive(true);
            SpaceSuit.SetActive(true);
            Spaceship.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "MenuEspacio" || SceneManager.GetActiveScene().name == "Espacio")
        {
            Crucifix.SetActive(true);
            SpaceSuit.SetActive(true);
            Spaceship.SetActive(true);
        }
    }
    void Update()
    {
        costSpeedTMP.text = costSpeed.ToString();
        costSpeedRed.text = costSpeed.ToString();
        levelSpeedTMP.text = levelSpeed.ToString();
        costBasketTMP.text = costBasket.ToString();
        costBasketRed.text = costBasket.ToString();
        levelBasketTMP.text = levelBasket.ToString();
        goldTMP.text = gold.ToString();
        costHeavenText.text = costHeaven.ToString();
        costHeavenRed.text = costHeaven.ToString();
        costSpaceText.text = costSpace.ToString();
        costSpaceRed.text = costSpace.ToString();
        costRevengeText.text = costRevenge.ToString();
        costRevengeRed.text = costRevenge.ToString();

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
