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
        target = GameObject.Find("Target").transform;
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);
        Vector3 zeroedYTarget = new Vector3(target.position.x, 0.5f, target.position.z);
        transform.LookAt(zeroedYTarget);
        if (distance > 0.1)
            transform.position += transform.forward * enemy.moveSpeed * Time.deltaTime;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
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
