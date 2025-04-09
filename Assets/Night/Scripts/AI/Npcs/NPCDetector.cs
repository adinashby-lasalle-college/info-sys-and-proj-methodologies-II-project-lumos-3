using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetector : MonoBehaviour
{
    Movement_NPC NPC;

    private void Start()
    {
        NPC = GetComponentInParent<Movement_NPC>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NPC.detecting = true;
            Debug.Log("enter");
        }
    }


}
