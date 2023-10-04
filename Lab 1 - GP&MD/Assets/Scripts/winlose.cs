using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class winlose : MonoBehaviour
{
    public TextMeshProUGUI wintext;
    public static bool playerDead;

    public GameObject vert;
    public GameObject follo;
    void Update()
    {
        if(HUDController.deaths > 50)
        {
            // Win 
            wintext.text = "Win";
            Time.timeScale = 0f;
        }


        if(playerDead)
        {
            wintext.text = "Lost";
        }
        
    }
}
