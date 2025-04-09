using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MonoBehaviour, I_NPC_State
{

    public void Enter(NPCController npc)
    {
        npc.agent.speed = npc.runSpeed;
    }

    public void SwitchState(NPCController npc)
    {
        npc.SetState(new PatrolState());
    }
}
