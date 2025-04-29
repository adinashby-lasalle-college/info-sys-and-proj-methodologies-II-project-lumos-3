using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageArea : MonoBehaviour
{
    [SerializeField] GarbageTaskManager taskManager;
    
    public void DeliverGarbage()
    {
        //Deliver Garbage and -1 in UI
        Debug.Log("Deliver Garbage");
        taskManager.DeliverGarbage();
        AudioPlayer player = gameObject.GetComponent<AudioPlayer>();
        player.PlaySound(0);
    }

    public void DeliverNpc()
    {
        AudioPlayer player = gameObject.GetComponent<AudioPlayer>();
        player.PlaySound(0);

        GameObject Manager = GameObject.FindGameObjectWithTag("GameManager");
        if (Manager != null)
        {
            //Game Over
            Manager.GetComponent<NewsPaperGenerator>().SwitchNews(1);
        }
    }
}
