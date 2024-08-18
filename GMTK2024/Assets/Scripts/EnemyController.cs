using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    public float enemyHealth;
    private Transform target;
    private Rigidbody enemyRb;
    private float scaling;
    private bool scaled = false;

    public MeshRenderer enemyMesh;
    private Color originColor;
    public Color damageColor;

    void Start()
    {
        enemyHealth = enemy.enemyHealth;
        target = GameObject.Find("Target").transform;
        enemyRb = GetComponent<Rigidbody>();
        scaling = transform.localScale.x;
        originColor = enemyMesh.material.color;
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
        scaling /= 1.5f;
        enemyHealth -= damage;
        if (!scaled)
        {
            transform.localScale = new Vector3(scaling, scaling, scaling);
            scaled = true;
        }

        if (enemyHealth <= 0)
        {
            Die();
        }
        if (enemyHealth >= damage)
            StartCoroutine(FlashDamage());

    }

    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator FlashDamage()
    {
        enemyMesh.material.color = damageColor;
        yield return new WaitForSeconds(0.2f);
        enemyMesh.material.color = originColor;
    }
}
