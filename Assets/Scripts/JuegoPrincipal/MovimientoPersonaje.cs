using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovimientoPersonaje : MonoBehaviour
{

    public float speed;
    private bool invertido = false;
    public GameObject Player;
    public Animator anim;
    private SpriteRenderer spriteRenderer;
    public ParticleSystem particulasPj;
    public float horizontal;
    private void Awake()
    {
        anim =GetComponentInChildren<Animator>();
        spriteRenderer = Player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            speed = GameManager.Instance.speed;
        } 
       
       
        if (invertido)
        {

            horizontal = Input.GetAxis("HorizontalInvertido");
            
            if (Input.GetKey(KeyCode.LeftArrow) || horizontal > 0)
            {

                anim.SetTrigger("Caminar");
                spriteRenderer.flipX = true;
                transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

            }
            
            else if (Input.GetKey(KeyCode.RightArrow) || horizontal < 0)
            {

                anim.SetTrigger("Caminar");
                spriteRenderer.flipX = false;
                transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
            }
            else
            {

                anim.SetTrigger("Parado");

            }
        }
        else
        {
            horizontal = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.LeftArrow) || horizontal < 0)
            {

                anim.SetTrigger("Caminar");
                spriteRenderer.flipX = false;
                transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

            }
            else if (Input.GetKey(KeyCode.RightArrow) || horizontal > 0)
            {

                anim.SetTrigger("Caminar");
                spriteRenderer.flipX = true;
                transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
            }
            else
            {

                anim.SetTrigger("Parado");

            }
        }
        
    }

    public void Invertido()
    {
        invertido = !invertido;
    }
}
