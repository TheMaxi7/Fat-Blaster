
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public string enemyName;
    public float enemyHealth;
    public float fat;
    public float moveSpeed;
    public GameObject model;
}
