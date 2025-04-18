using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetector : MonoBehaviour
{
    Movement_NPC NPC;
    bool isInNPCDetection;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NPC.detecting = false;
            Debug.Log("Exit");
        }
    }

    private void Update()
    {
        if (NPC.detecting)
        {
            if (timer < detectTime)
            {
                timer += Time.deltaTime;
            }

            if (timer >= detectTime && !detected)
            {
                NPC.DisturbNPC();
                detected = true; // prevent multiple calls
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer < 0f) timer = 0f;
        }
    }

    public float detectTime = 4f;
    public float timer = 0f;
    private bool detected = false;


}
