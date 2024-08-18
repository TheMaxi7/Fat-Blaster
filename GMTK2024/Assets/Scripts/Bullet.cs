using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootingSpeed;
    public Rigidbody bulletRb;
    public float damage;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
        }
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<BossController>().TakeDamage(damage);
        }
    }
}
