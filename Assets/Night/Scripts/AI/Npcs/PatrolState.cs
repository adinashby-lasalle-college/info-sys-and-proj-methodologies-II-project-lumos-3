using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonoBehaviour, I_NPC_State
{

    public void Enter(NPCController npc)
    {
        npc.agent.speed = npc.patrolSpeed;
    }

    public void SwitchState(NPCController npc)
    {
        npc.SetState(new RunState());
    }
}
