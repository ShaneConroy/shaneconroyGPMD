using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(ExplodeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ExplodeCoroutine()
    {
        yield return new WaitForSeconds(3);
        animator.SetTrigger("Exploding");

    }
}
