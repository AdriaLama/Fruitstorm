using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool hasCrucifix = false;
    public bool hasSpaceSuit = false;
    public bool hasSpacecraft = false;
    public int gold;
    public int costSpeed;
    public int levelSpeed;
    public int costBasket;
    public int levelBasket;
    public int costHealth;
    public int levelHealth;
    public float speed;
    public float basketScaleX;
    public float basketScaleY;
    public float basketPosY;
    public int health;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
    private void Start()
    {
        Time.timeScale = 1f;
    }
   
}
