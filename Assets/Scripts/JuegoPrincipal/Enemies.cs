using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float enemiesLifes;
    public float miniBossLifes;
    public float bossLifes;

    public Transform player;
    public float speed = 5f;
    public float stopDistance = 6f;
    private bool hasReachedPlayer = false;
    private float initialYPosition;

    public GameObject balaPrefab;
    public float intervaloDisparo = 3f;
    Collider2D coll;
    private bool hasStartedShooting = false;
    public GameObject[] powerUpPrefabs; // Lista de prefabs de power-ups
    [Range(0, 1)]
    public float powerUpDropChance = 0.2f; // Probabilidad de soltar un power-up (0.2 = 20%)


    void Start()
    {
        initialYPosition = transform.position.y;

        coll = GetComponent<Collider2D>();
        if (coll.CompareTag("MiniBoss") || coll.CompareTag("MiniBoss2"))
        {
            intervaloDisparo = 2f;
        }
        if (coll.CompareTag("Boss"))
        {
            intervaloDisparo = 1f;
        }
    }
    void Update()
    {
        if (!hasReachedPlayer)
        {
            Move();
        }
        else
        {
            LookAtPlayer();
            if (!hasStartedShooting)
            {
                InvokeRepeating("Disparar", 0f, intervaloDisparo);
                hasStartedShooting = true;
            }
        }
    }
    void Move()
    {
        float step = speed * Time.deltaTime;

        transform.Translate(Vector3.down * step);

        float distanceMoved = initialYPosition - transform.position.y;

        if (distanceMoved >= stopDistance)
        {
            hasReachedPlayer = true;
        }
    }

    void LookAtPlayer()
    {
        if (player != null) { 
        Vector3 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }
    void Disparar()
    {
        GameObject temp = Instantiate(balaPrefab, transform.position, transform.rotation);
        Destroy(temp, 1);
    }

    public void DropPowerUp()
    {
        float randomValue = Random.Range(0f, 1f);
        if (randomValue <= powerUpDropChance)
        {
            // Seleccionar un power-up aleatorio de la lista
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);
            GameObject selectedPowerUp = powerUpPrefabs[randomIndex];

            // Instanciar el power-up en la posición de la nave
            Instantiate(selectedPowerUp, transform.position, Quaternion.identity);
        }
    }

}
