using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPChitbox : MonoBehaviour
{
    [SerializeField] GameObject NPC;
    [SerializeField] GameObject NPCBody;

    public void Stun()
    {
        Instantiate(NPCBody, NPC.transform.position, NPC.transform.rotation);
        Destroy(NPC);
    }
}
