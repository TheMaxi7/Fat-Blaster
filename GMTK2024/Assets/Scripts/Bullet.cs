
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootingSpeed;
    public Rigidbody bulletRb;
    public float damage;
    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject, 0.2f);
        }
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<BossController>().TakeDamage(damage);
            Destroy(gameObject, 0.2f);
        }
        if (collision.gameObject.layer == 3 || collision.gameObject.layer == 10)
        {
            Destroy(gameObject);
        }

    }
}
