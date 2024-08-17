using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("General UI")]
    public GameObject gameOverScreen;
    public TextMeshProUGUI playerFatText;

    void Update()
    {
        playerFatText.text = PlayerManager.instance.playerFat + "";
        if (GameManager.instance.gameOver == true)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(false);
        }
    }


}
