using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpsSpawning : MonoBehaviour
{
    public PickUp[] pickUps;
    private float spawningTimer;

    void Start()
    {
        spawningTimer = Random.Range(10, 20);
    }
    void Update()
    {
        spawningTimer -= Time.deltaTime;
        if (spawningTimer <= 0)
        {
            spawningTimer = Random.Range(10, 20);
            SpawnCollectible();
        }
    }

    private PickUp FindCollectibleToSpawn()
    {
        float totalChance = 0;
        foreach (PickUp collectible in pickUps)
        {
            totalChance += collectible.rarity;
        }

        float rand = Random.Range(0, totalChance);
        float cumulativeChance = 0f;
        foreach (PickUp collectible in pickUps)
        {
            cumulativeChance += collectible.rarity;
            if (rand <= cumulativeChance)
            {
                return collectible;
            }
        }
        return null;
    }

    private void SpawnCollectible()
    {
        var collectibleToSpawn = FindCollectibleToSpawn();
        var whereToSpawn = FindSpawnLocation();
        Instantiate(collectibleToSpawn.model, whereToSpawn, Quaternion.identity);
    }

    private Vector3 FindSpawnLocation()
    {
        float posX = Random.Range(-18.5f, 19f);
        float posZ = Random.Range(-12f, 8.35f);
        float posY = 1f;
        return new Vector3(posX, posY, posZ);
    }
}
