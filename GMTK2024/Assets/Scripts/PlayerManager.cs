using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public float playerFat;
    public float basicFatLoss;
    public float speedMovement = 10;
    private float loseFatTimer = 5;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        CheckFatCondition();
        LoseFat();
    }

    public void IncreaseFat(float fat)
    {
        playerFat += fat;
    }

    public void DecreaseFat(float fat)
    {
        playerFat -= fat;
    }

    void CheckFatCondition()
    {
        if (playerFat >= 300)
        {
            GameManager.instance.GameOver();
        }
    }

    public void IncreaseSpeed()
    {
        StartCoroutine(BoostSpeed());
    }

    public IEnumerator BoostSpeed()
    {
        instance.speedMovement += 10f;
        yield return new WaitForSeconds(15f);
        instance.speedMovement -= 10f;
    }

    public void IncreaseFireRate()
    {
        StartCoroutine(BoostFireRate());
    }

    public IEnumerator BoostFireRate()
    {
        Shooting.shootingRate /= 2;
        yield return new WaitForSeconds(15f);
        Shooting.shootingRate *= 2;
    }

    private void LoseFat()
    {
        if (playerFat > 100)
        {
            loseFatTimer -= Time.deltaTime;
            if (loseFatTimer <= 0)
            {
                playerFat -= basicFatLoss;
                loseFatTimer = 5;
            }
        }
    }

}
