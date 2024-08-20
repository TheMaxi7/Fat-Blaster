
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy[] enemiesList;
    public float spawnTime;
    private float timer;
    public bool canSpawn;
    int indexEnemyToSpawn;

    public Transform spawnerPosition;

    void Start()
    {
        timer = spawnTime;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnEnemy();
            timer = spawnTime;
        }

    }

    public void SpawnEnemy()
    {
        GameObject enemyToSpawn = SelectEnemy();
        enemyToSpawn.GetComponent<EnemyController>().enemy = enemiesList[indexEnemyToSpawn];
        var spawnedEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        spawnedEnemy.GetComponent<EnemyController>().enemyMesh = spawnedEnemy.GetComponent<MeshRenderer>();
    }

    public GameObject SelectEnemy()
    {
        indexEnemyToSpawn = Random.Range(0, enemiesList.Length - 1);
        return enemiesList[indexEnemyToSpawn].model;
    }
}
