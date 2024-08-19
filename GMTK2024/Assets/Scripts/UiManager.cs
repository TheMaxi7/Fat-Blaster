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
    public TextMeshProUGUI playerFatText;
    public TextMeshProUGUI moveSpeedText;

    void Update()
    {
        playerFatText.text = PlayerManager.instance.playerFat + "";
        moveSpeedText.text = PlayerManager.instance.speedMovement + "";
        if (GameManager.instance.gameOver == true)
        {
            gameOverScreen.SetActive(true);
            fatBar.SetActive(false);
        }
        else
        {
            gameOverScreen.SetActive(false);
            fatBar.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
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
        }
        else
        {
            pauseGameScreen.SetActive(false);
            fatBar.SetActive(true);
        }
    }


}
