using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuscript : MonoBehaviour
{

    public void onPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void onDiffButton()
    {
        SceneManager.LoadScene(2);
    }

    public void onQuitButton()
    {
        Application.Quit();
    }

}

