using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    public void onButtonStart()
    {
        SceneManager.LoadScene("main");
    }
}
