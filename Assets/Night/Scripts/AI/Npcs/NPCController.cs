using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

public class NPCController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float patrolSpeed = 1f;
    public float runSpeed = 2f;

    private I_NPC_State currentState;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        SetState(new PatrolState());
    }

    public void SetState(I_NPC_State newState)
    {
        currentState = newState;
        currentState.Enter(this);
    }
}
