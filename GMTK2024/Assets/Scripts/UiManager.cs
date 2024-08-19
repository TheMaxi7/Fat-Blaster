using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("General UI")]
    public GameObject gameOverScreen;
    public GameObject pauseGameScreen;
    public GameObject fatBar;
    public GameObject bossTimer;
    public GameObject winPanel;
    private int minutes, seconds;

    void Update()
    {
        BossTimer();

        if (GameManager.instance.bossSpawned)
            bossTimer.SetActive(false);
        bossTimer.GetComponent<TextMeshProUGUI>().text = "MAD CUPCAKE IN " + minutes + ":" + seconds;
        if (GameManager.instance.gameOver == true)
        {
            gameOverScreen.SetActive(true);
            fatBar.SetActive(false);
            bossTimer.SetActive(false);
        }
        else
        {
            if (GameManager.instance.endGame == false || GameManager.instance.gamePaused == false)
            {
                gameOverScreen.SetActive(false);
                fatBar.SetActive(true);
                bossTimer.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.endGame && !GameManager.instance.gameOver)
        {
            if (GameManager.instance.gamePaused)
            {
                GameManager.instance.Continue();
            }
            else
            {
                GameManager.instance.PauseGame();
            }

        }

        if (GameManager.instance.gamePaused == true)
        {
            pauseGameScreen.SetActive(true);
            fatBar.SetActive(false);
            bossTimer.SetActive(false);
        }
        else
        {
            pauseGameScreen.SetActive(false);
        }

        if (GameManager.instance.endGame)
        {
            StartCoroutine(ActivateWinPanel());
            fatBar.SetActive(false);
            bossTimer.SetActive(false);
        }
        else
        {
            winPanel.SetActive(false);
        }
    }

    private void BossTimer()
    {
        minutes = Mathf.FloorToInt(GameManager.instance.bossTimer / 60);
        seconds = Mathf.FloorToInt(GameManager.instance.bossTimer % 60);
    }

    private IEnumerator ActivateWinPanel()
    {
        yield return new WaitForSeconds(2f);
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }


}
