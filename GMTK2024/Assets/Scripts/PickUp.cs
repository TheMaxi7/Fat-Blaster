
using UnityEngine;


public enum type
{
    Speedboost,
    FatDecrease,
    FireRateIncrease,
    TimeSlow,
}

[CreateAssetMenu(fileName = "New PickUp", menuName = "PickUp")]

public class PickUp : ScriptableObject
{
    public string powerUpName;
    public Sprite Icon;
    public int rarity;
    public GameObject model;
    public type bonusType;
}
