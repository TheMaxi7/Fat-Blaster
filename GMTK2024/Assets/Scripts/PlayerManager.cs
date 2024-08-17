using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public float playerFat;
    public float basicFatLoss;
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

}
