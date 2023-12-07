using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{

    public static int currentCam = 0;
    public Camera lowCam; // 0
    public Camera midCam; // 1
    public Camera highCam;// 2

    public GameObject player;
    public void onButtonMinus()
    {
        if(currentCam == 1) // If on mid cam
        {
            midCam.enabled = false;
            lowCam.enabled = true;
            currentCam = 0;
        }
        if(currentCam == 2) // If on high cam
        {
            highCam.enabled = false;
            midCam.enabled = true;
            currentCam = 1;
        }
    }

    public void onButtonPlus() 
    { 
        if(currentCam == 0) // If on low cam
        {
            midCam.enabled = true;
            lowCam.enabled = false;
            currentCam = 1;
        }
        else if(currentCam == 1) // // If on mid cam
        {
            midCam.enabled = false;
            highCam.enabled = true;
            currentCam = 2;
        }
    }

    public void Update()
    {
        // Camera follows player
        lowCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -5);
        midCam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
