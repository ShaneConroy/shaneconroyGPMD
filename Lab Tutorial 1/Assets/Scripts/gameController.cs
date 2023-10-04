using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text gameOverText;

    private void Start()
    {
        gameOverText.enabled = false;
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0f; // Pause the game
    }
}
