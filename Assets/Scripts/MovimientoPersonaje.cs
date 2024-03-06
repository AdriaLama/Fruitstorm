using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    private float speed = 10f;
    private bool invertido = false;
    public Sprite jodebayayiyas;
    public Sprite Player;
    public SpriteRenderer spriteRenderer;
    public Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        PlayerPrefs.GetFloat("speedlvlup", speed);
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
        PlayerPrefs.SetFloat("speed", speed);
        PlayerPrefs.Save();

        float horizontal;
        if (invertido)
        {
            horizontal = Input.GetAxis("HorizontalInvertido");
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRenderer.sprite = jodebayayiyas;
                spriteRenderer.transform.localScale = new Vector3(1, 1, 1);
                anim.SetTrigger("jodiendopachiris");


            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                spriteRenderer.sprite = jodebayayiyas;
            }
            else
            {
                spriteRenderer.sprite = Player;
            }
        }
        transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;



    }

    public void UpdateSpeed()
    {

    }

    public void Invertido()
    {
        invertido = !invertido;
    }
}