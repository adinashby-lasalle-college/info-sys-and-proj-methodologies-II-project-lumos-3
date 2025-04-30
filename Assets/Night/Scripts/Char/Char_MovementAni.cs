using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_MovementAni : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public float moveThreshold = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > moveThreshold)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
