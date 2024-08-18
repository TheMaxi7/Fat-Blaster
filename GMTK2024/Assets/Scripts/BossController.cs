using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Enemy enemy;
    public float enemyHealth;
    private Transform target;
    private Rigidbody enemyRb;
    private float scaling;
    void Start()
    {
        enemyHealth = enemy.enemyHealth;
        target = GameObject.Find("Target").transform;
        enemyRb = GetComponent<Rigidbody>();
        scaling = transform.localScale.x;
    }

    void FixedUpdate()
    {
        target.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(target.position);
        enemyRb.MovePosition(transform.position + transform.forward * Time.deltaTime * enemy.moveSpeed);
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
        scaling /= 1.02f;
        enemyHealth -= damage;
        transform.localScale = new Vector3(scaling, scaling, scaling);
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
