
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver = false;
    public bool gamePaused = false;
    public bool endGame = false;
    public float bossTimer = 300;
    public GameObject boss;
    public Transform bossSpawnTransform;
    public GameObject bossInstance;
    public bool bossSpawned = false;
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
    void Start()
    {
        //SoundManager.PlaySound(SoundType.GameMusic, 0.1f);
    }
    void Update()
    {
        bossTimer -= Time.deltaTime;
        if (bossTimer <= 0 && bossSpawned == false)
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
        endGame = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
        PlayerManager.instance.playerFat = 150;
    }

    public void NewGame()
    {
        gameOver = false;
        endGame = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }

    void SpawnBoss()
    {
        bossInstance = Instantiate(boss, bossSpawnTransform.position, quaternion.identity);
        SoundManager.PlaySound(SoundType.BossSpawn, 0.5f);
        bossInstance.GetComponent<BossController>().enemyMesh = bossInstance.GetComponent<MeshRenderer>();
        bossSpawned = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        gameOver = false;
        gamePaused = false;
        endGame = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gamePaused = true;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        gamePaused = false;
    }

}
