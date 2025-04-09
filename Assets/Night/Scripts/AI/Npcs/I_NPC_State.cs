using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_NPC_State
{
    void Enter(NPCController NPC);
    void SwitchState(NPCController NPC);
}
