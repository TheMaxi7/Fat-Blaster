using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;
    private Transform target;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {

        float distance = Vector3.Distance(transform.position, target.position);
        transform.LookAt(target.position);
        if (distance > 0.1)
            transform.position += transform.forward * enemy.moveSpeed * Time.deltaTime;
    }
}
