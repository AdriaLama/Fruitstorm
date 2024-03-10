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

    void Start()
    {
        initialYPosition = transform.position.y; 
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
        Vector3 direction = (player.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
}
