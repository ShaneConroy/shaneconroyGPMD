using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class mouseMoverScript : MonoBehaviour
{
    public static Vector3 mouseTargetPos;
    private float objSpeed = 999f;

    public Camera lowCam;
    public Camera midCam;
    public Camera highCam;
    void Start()
    {
        mouseTargetPos = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (cameraController.currentCam == 0)
            {
                mouseTargetPos = lowCam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (cameraController.currentCam == 1)
            {
                mouseTargetPos = midCam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (cameraController.currentCam == 2)
            {
                mouseTargetPos = highCam.ScreenToWorldPoint(Input.mousePosition);
            }
            mouseTargetPos.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, mouseTargetPos, objSpeed * Time.deltaTime);
    }
}
