using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour
{

    public void onButtonRetry()
    {
        SceneManager.LoadScene(1);
        catController.dead = false;
    }

    public void onButtonMainMenu()
    {
        SceneManager.LoadScene(0);
        catController.dead = false;
    }
}
