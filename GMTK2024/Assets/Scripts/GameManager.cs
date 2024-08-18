using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver = false;
    public float bossTimer = 300;
    public GameObject boss;
    public Transform bossSpawnTransform;
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
        bossTimer -= Time.deltaTime;
        if (bossTimer <= 0)
        {
            SpawnBoss();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;
    }

    public void TryAgain()
    {
        gameOver = false;
        Time.timeScale = 1;
        PlayerManager.instance.playerFat = 200;
        SceneManager.LoadScene("Main");
    }

    void SpawnBoss()
    {
        Instantiate(boss, bossSpawnTransform.position, quaternion.identity);
    }
}
