using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header("General UI")]
    public GameObject gameOverScreen;
    public GameObject pauseGameScreen;
    public GameObject fatBar;
    public GameObject bossTimer;
    public GameObject winPanel;
    public GameObject bossHpBar;
    public GameObject settingsPanel;
    private bool openSettings;
    public Image hpBossBar;



    private int minutes, seconds;

    void Update()
    {
        if (GameManager.instance.bossSpawned)
        {
            UpdateBossBar();
            bossHpBar.SetActive(true);
        }

        BossTimer();
        bossTimer.GetComponent<TextMeshProUGUI>().text = "MAD CUPCAKE IN " + minutes + ":" + seconds;
        if (GameManager.instance.gameOver == true)
        {
            gameOverScreen.SetActive(true);
            fatBar.SetActive(false);
            bossTimer.SetActive(false);
            bossHpBar.SetActive(false);
        }
        else
        {
            if (GameManager.instance.endGame == false || GameManager.instance.gamePaused == false)
            {
                gameOverScreen.SetActive(false);
                fatBar.SetActive(true);
                if (!GameManager.instance.bossSpawned)
                    bossTimer.SetActive(true);
                else
                    bossTimer.SetActive(false);
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.endGame && !GameManager.instance.gameOver)
        {
            if (GameManager.instance.gamePaused)
            {
                GameManager.instance.Continue();
                settingsPanel.SetActive(false);
                openSettings = false;
            }
            else
            {
                GameManager.instance.PauseGame();
            }

        }

        if (GameManager.instance.gamePaused == true)
        {
            if (!openSettings)
                pauseGameScreen.SetActive(true);
            fatBar.SetActive(false);
            bossTimer.SetActive(false);
            bossHpBar.SetActive(false);

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
            bossHpBar.SetActive(false);
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

    private void UpdateBossBar()
    {
        if (GameManager.instance.bossInstance != null)
        {
            float startHp = GameManager.instance.bossInstance.GetComponent<BossController>().enemy.enemyHealth;
            float hp = GameManager.instance.bossInstance.GetComponent<BossController>().enemyHealth;
            float currentHp = hp / startHp;
            hpBossBar.fillAmount = currentHp;
        }

    }

    public void CloseSetting()
    {

        settingsPanel.SetActive(false);
        pauseGameScreen.SetActive(true);
        openSettings = false;
    }
    public void OpenSettings()
    {

        settingsPanel.SetActive(true);
        pauseGameScreen.SetActive(false);
        openSettings = true;


    }

}
