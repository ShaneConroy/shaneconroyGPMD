using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class diffMenu : MonoBehaviour
{
    public TMP_Text diffText;

    // Based on the button chosen, changes difficulty.
    // Sends int off to game manager. Game mananger deals with diff
    public void onEasyButton()
    {
        gameManager.difficulty = 1;
    }
    public void onMediumButton()
    {
        gameManager.difficulty = 2;
    }
    public void onHardButton()
    {
        gameManager.difficulty = 3;
    }
    public void onBackButton()
    {
        SceneManager.LoadScene(0);
    }

    // Updates the displayed difficulty
    public void Update()
    {
        if (gameManager.difficulty == 1)
        {
            diffText.text = "Difficulty: Easy";
        }
        else if (gameManager.difficulty == 2)
        {
            diffText.text = "Difficulty: Medium";
        }
        else if (gameManager.difficulty == 3)
        {
            diffText.text = "Difficulty: Hard";
        }
    }

}
