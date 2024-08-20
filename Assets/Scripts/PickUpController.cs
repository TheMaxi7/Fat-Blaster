
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public PickUp pickUp;
    private Transform target;
    private type pickUpType;
    void Start()
    {
        target = GameObject.Find("Target").transform;
        pickUpType = pickUp.bonusType;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            switch (pickUpType)
            {
                case type.Speedboost:
                    SoundManager.PlaySound(SoundType.CarrotSFX, 0.22f);
                    PlayerManager.instance.IncreaseSpeed();
                    break;
                case type.FatDecrease:
                    SoundManager.PlaySound(SoundType.AppleSFX, 0.22f);
                    PlayerManager.instance.DecreaseFat(20);
                    break;
                case type.FireRateIncrease:
                    SoundManager.PlaySound(SoundType.TomatoSFX, 0.22f);
                    PlayerManager.instance.IncreaseFireRate();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }
    public void IncreaseSpeed()
    {
        PlayerManager.instance.speedMovement += 10f;
        float timer = 15f;
        while (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
            PlayerManager.instance.speedMovement -= 10f;
    }
}
