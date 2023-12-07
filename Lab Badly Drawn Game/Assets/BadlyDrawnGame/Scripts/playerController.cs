using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private float playerSpeed = 5.0f;
    private Vector3 targetPos;

    public Camera lowCam;
    public Camera midCam;
    public Camera highCam;

    public GameObject boundSphere;
    public GameObject mousePoint;

    public static int lives = 3;

    void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        movement();

        assaulting();
    }

    void movement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (cameraController.currentCam == 0)
            {
                targetPos = lowCam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (cameraController.currentCam == 1)
            {
                targetPos = midCam.ScreenToWorldPoint(Input.mousePosition);
            }
            if (cameraController.currentCam == 2)
            {
                targetPos = highCam.ScreenToWorldPoint(Input.mousePosition);
            }
            targetPos.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, playerSpeed * Time.deltaTime);
    }


    void assaulting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AssaultCoroutine());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            lives--;
            SceneManager.LoadScene("main");
            if(lives < 0)
            {
                SceneManager.LoadScene("lost");
            }
        }
    }

    IEnumerator AssaultCoroutine()
    {
        float timer = .25f;

        boundSphere.transform.position = this.transform.position + new Vector3(.33f, .15f, 0);

        while (timer > 0f)
        {
            boundSphere.transform.RotateAround(this.transform.position, Vector3.forward, 500 * Time.deltaTime);
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}
