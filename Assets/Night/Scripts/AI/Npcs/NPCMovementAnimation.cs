using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovementAnimation : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public float moveThreshold = 0.1f; // To ignore tiny movements

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (agent.velocity.magnitude > moveThreshold)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
