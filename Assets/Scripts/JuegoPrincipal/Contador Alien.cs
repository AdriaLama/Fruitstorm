using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorAlien : MonoBehaviour
{
    public float currTime = 0;
    public float spawnTime = 1f;
    public GameObject AlienRecolect;
    public float time;
    public float disappearTime;
    public int contadorAlien;
    public AudioSource alienSound;
    public AudioClip Alienn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        if (currTime > spawnTime && contadorAlien <= 4)
        {
            currTime = 0;
            contadorAlien++;
            AlienRecolect.SetActive(true);
            alienSound.PlayOneShot(Alienn);
        }

        if (AlienRecolect.activeSelf)
        {
            time += Time.deltaTime; 
            
            if(time >= disappearTime)
            {
                time = 0;
                AlienRecolect.SetActive(false);
                alienSound.Pause();
                
                
            }
        }
        
    }
}
