using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager Instance { get; private set; }

    public int ComboCount { get; set; } = 0;
    public float GoldGained { get; set; } = 0;
    public int ComboGold { get; set; } = 0;
    public int TotalComboGold { get; set; } = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
