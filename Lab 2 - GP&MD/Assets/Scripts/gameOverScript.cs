using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{
    public TMP_Text crates;
    public TMP_Text time;
    public TMP_Text coins;

    public static int highCoin = 0;
    public static int highCrate = 0;
    public static float highTime = 0;

    public void Update()
    {
        // Keeps track of high scores
        if (canvasScript.coinAmount > highCoin)
        {
            highCoin = canvasScript.coinAmount;
        }
        if (highCrate < canvasScript.cratesDeath)
        {
            highCrate = canvasScript.cratesDeath;
        }
        if (highTime < canvasScript.timer)
        {
            highTime = canvasScript.timer;
        }

        crates.text = highCrate.ToString();
        coins.text = highCoin.ToString();
        time.text = highTime.ToString("F1");
    }
    public void onButtonRetry()
    {
        SceneManager.LoadScene(1);
        catController.dead = false;
        canvasScript.timer = 0;
        canvasScript.cratesDeath = 0;
        canvasScript.coinAmount = 0;
    }

    public void onButtonMainMenu()
    {
        SceneManager.LoadScene(0);
        catController.dead = false;
    }
}
