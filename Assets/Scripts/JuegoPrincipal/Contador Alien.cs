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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime > spawnTime)
        {
            currTime = 0;
            AlienRecolect.SetActive(true);
        }

        if (AlienRecolect.activeSelf)
        {
            time += Time.deltaTime; 
            
            if(time >= disappearTime)
            {
                time = 0;
                AlienRecolect.SetActive(false);
                AlienRecolect.transform.position.x = -17;
            }
        }
    }
}
