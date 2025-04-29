using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDetector : MonoBehaviour
{
    Movement_NPC NPC;
    bool isInNPCDetection;
    [SerializeField] Slider UISlider_Detect;
    [SerializeField] Slider UISlider_Run;

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
                UISlider_Detect.value = timer / detectTime;
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

        if (detected)
        {
            if (RunningTimer < RunningTime)
            {
                RunningTimer += Time.deltaTime;
                UISlider_Run.value = RunningTimer / RunningTime;
            }

            if (RunningTimer >= RunningTime)
            {
                GameObject Manager = GameObject.FindGameObjectWithTag("GameManager");
                if (Manager != null) 
                {
                    //Game Over
                    Manager.GetComponent<NewsPaperGenerator>().SwitchNews(2);
                    Manager.GetComponent<NewsPaperGenerator>().CallOutNew();
                }
            }
        }
    }

    public float detectTime = 4f;
    public float timer = 0f;
    private bool detected = false;


    public float RunningTime = 10f;
    public float RunningTimer = 0f;

}
