using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseScript : MonoBehaviour
{
    public void onButtonRestart()
    {
        playerController.lives = 3;
        SceneManager.LoadScene("main");
    }

    public void onbuttonQuit()
    {
        Application.Quit();
    }
}
