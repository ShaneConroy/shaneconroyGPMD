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
    private float timer = 0f;
    public static int cratesDeath = 0;
    void Update()
    {
        if(catController.dead == false)
        {
            timer += Time.deltaTime;
        }

        timeAlive.text = "Time alive: " + timer.ToString("F1");

        cratesKilled.text = "Crates killed: " + cratesDeath.ToString();
    }
}
