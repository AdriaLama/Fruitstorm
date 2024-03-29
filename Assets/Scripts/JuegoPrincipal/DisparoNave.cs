using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoNave : MonoBehaviour
{
    public GameObject bala;
    Collider2D coll;
    private AudioSource audioSource;
    public AudioClip BalaNave;
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && coll.enabled)
        {
            GameObject temp = Instantiate(bala, transform.position, transform.rotation);
            Destroy(temp, 1);
            AudioSource.PlayClipAtPoint(BalaNave, transform.position);
        }
    }
}
