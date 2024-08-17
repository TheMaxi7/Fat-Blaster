using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public float enemyHealth;
    private Transform target;
    void Start()
    {
        enemyHealth = enemy.enemyHealth;
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);
        transform.LookAt(target.position);
        if (distance > 0.1)
            transform.position += transform.forward * enemy.moveSpeed * Time.deltaTime;
        else
        {
            PlayerManager.instance.IncreaseFat(enemy.fat);
            Destroy(gameObject);
        }

    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
