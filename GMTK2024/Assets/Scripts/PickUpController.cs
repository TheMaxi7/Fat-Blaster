using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public PickUp pickUp;
    private Transform target;
    private type pickUpType;
    void Start()
    {
        target = GameObject.Find("Player").transform;
        pickUpType = pickUp.bonusType;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < 0.5)
        {
            switch (pickUpType)
            {
                case type.Speedboost:
                    PlayerManager.instance.IncreaseSpeed();
                    break;
                case type.FatDecrease:
                    PlayerManager.instance.DecreaseFat(20);
                    break;
                case type.FireRateIncrease:
                    PlayerManager.instance.IncreaseFireRate();
                    break;
                //case type.TimeSlow:
                //PlayerManager.instance.SlowTime();
                //break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }

    public void IncreaseSpeed()
    {
        Debug.Log("preso carota");
        PlayerManager.instance.speedMovement += 10f;
        Debug.Log("pta");
        float timer = 15f;
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
            PlayerManager.instance.speedMovement -= 10f;
    }
}
