using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoPersonaje : MonoBehaviour
{

    private float speed = 10f;
    private bool invertido = false;
    public GameObject Player;
    public Animator anim;
    private SpriteRenderer spriteRenderer;



    private void Awake()
    {
        anim =GetComponentInChildren<Animator>();
        spriteRenderer = Player.GetComponent<SpriteRenderer>();
        PlayerPrefs.GetFloat("speedlvlup", speed);
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

                anim.SetTrigger("Caminar");
                spriteRenderer.flipX = false;


            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {

                anim.SetTrigger("Caminar");
                spriteRenderer.flipX = true;

            }
            else
            {

                anim.SetTrigger("Parado");

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
