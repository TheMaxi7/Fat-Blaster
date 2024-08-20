
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
        float posX = Random.Range(-15.5f, 16f);
        float posZ = Random.Range(-11.7f, 8.5f);
        float posY = 1f;
        return new Vector3(posX, posY, posZ);
    }
}
