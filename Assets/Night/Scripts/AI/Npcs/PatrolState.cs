using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour, I_NPC_State
{
    RunState runState;

    private void Start()
    {
        runState = GetComponent<RunState>();
    }

    public void Enter(NPCController npc)
    {
        npc.agent.speed = npc.patrolSpeed;
    }

    public void SwitchState(NPCController npc)
    {
        npc.SetState(runState);
    }
}
