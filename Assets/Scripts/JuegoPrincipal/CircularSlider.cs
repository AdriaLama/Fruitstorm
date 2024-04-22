using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularSlider : MonoBehaviour
{
    public GameObject reloj;
    public Image image;
    public float decreaseTimer;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = image.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UI ui = FindObjectOfType<UI>();
        float remainingTimeRatio = ui.currentTime / ui.startingTime;

        image.fillAmount = remainingTimeRatio;
    }
}
