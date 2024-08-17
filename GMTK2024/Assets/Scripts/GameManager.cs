using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameOver = false;
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
}
