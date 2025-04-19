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
    public float IdleDur = 5f;
    public float D_IdleDur = 1f;
    public float MoveDur = 5f;
    public float D_MoveDur = 3f;
    public float MoveRadius = 10f;
    public float D_MoveRadius = 15f;

    public I_NPC_State currentState;

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
