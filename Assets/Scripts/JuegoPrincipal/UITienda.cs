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
    public int costHealth;
    public TMP_Text costHealthTMP;
    public TMP_Text costHealthRed;
    public int levelHealth;
    public TMP_Text levelHealthTMP;
    public float speed;
    public float scaleX;
    public float scaleY;
    public float pos;
    public int health;
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
    public GameObject redButtonHealth;
    public GameObject redButtonCrucifix;
    public GameObject redButtonSpaceSuit;
    public GameObject redButtonSpacecraft;
    public GameObject maxSpeed;
    public GameObject maxBasket;
    public GameObject maxHealth;
    public GameObject ownedCrucifix;
    public GameObject ownedSpaceSuit;
    public GameObject ownedSpacecraft;

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
        costHealthTMP.text = costHealth.ToString();
        costHealthRed.text = costHealth.ToString();
        levelHealthTMP.text = levelHealth.ToString();
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
            costHealth = GameManager.Instance.costHealth;
            levelHealth = GameManager.Instance.levelHealth;
            speed = GameManager.Instance.speed;
            scaleX = GameManager.Instance.basketScaleX;
            scaleY = GameManager.Instance.basketScaleY;
            pos = GameManager.Instance.basketPosY;
            health = GameManager.Instance.health;
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
        if (gold >= costHealth)
        {
            redButtonHealth.SetActive(false);
        }
        else
        {
            redButtonHealth.SetActive(true);
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
        if (levelSpeed >= 5)
        {
            maxSpeed.SetActive(true);
            GameManager.Instance.costSpeed = 0;
        }
        else
        {
            maxSpeed.SetActive(false);
        }
        if (levelBasket >= 5)
        {
            maxBasket.SetActive(true);
            GameManager.Instance.costBasket = 0;
        }
        else
        {
            maxBasket.SetActive(false);
        }
        if (levelHealth >= 11)
        {
            maxHealth.SetActive(true);
            GameManager.Instance.costHealth = 0;
        }
        else
        {
            maxHealth.SetActive(false);
        }
        if (hasCrucifix)
        {
            ownedCrucifix.SetActive(true);
        }
        else
        {
            ownedCrucifix.SetActive(false);
        }
        if (hasSpaceSuit)
        {
            ownedSpaceSuit.SetActive(true);
        }
        else
        {
            ownedSpaceSuit.SetActive(false);
        }
        if (hasSpacecraft)
        {
            ownedSpacecraft.SetActive(true);
        }
        else
        {
            ownedSpacecraft.SetActive(false);
        }
    }

    public void LevelUpSpeed()
    {
        if (gold >= costSpeed && levelSpeed < 5)
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
        if (gold >= costBasket && levelBasket < 5)
        {
            audioSource.PlayOneShot(Mejoras);
            GameManager.Instance.basketScaleX += 0.05f;
            GameManager.Instance.basketScaleY += 0.05f;
            GameManager.Instance.basketPosY += 0.25f;
            GameManager.Instance.levelBasket++;
            GameManager.Instance.gold -= costBasket;
            GameManager.Instance.costBasket *= 5;
        }
    }

    public void LevelUpHealth()
    {
        if (gold >= costHealth && levelHealth < 11)
        {
            audioSource.PlayOneShot(Mejoras);
            GameManager.Instance.health += 1;
            GameManager.Instance.levelHealth++;
            GameManager.Instance.gold -= costHealth;
            GameManager.Instance.costHealth *= 2;
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
