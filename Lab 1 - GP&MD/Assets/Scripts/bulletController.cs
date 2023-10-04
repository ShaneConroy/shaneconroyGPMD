using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 20f;
    public float lifespan = 1.5f;
    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
