using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UI;
using System.Threading;

public class canvasScript : MonoBehaviour
{
    public TMP_Text cratesKilled;
    public TMP_Text timeAlive;
    public TMP_Text coinsCollected;
    public static float timer = 0f;
    public static int cratesDeath = 0;
    public static int coinAmount = 0;
    void Update()
    {
        if(catController.dead == false)
        {
            timer += Time.deltaTime;
        }

        timeAlive.text = "Time alive: " + timer.ToString("F1");

        cratesKilled.text = "Crates killed: " + cratesDeath.ToString();

        coinsCollected.text = "Coins: " + coinAmount.ToString();
    }
}
