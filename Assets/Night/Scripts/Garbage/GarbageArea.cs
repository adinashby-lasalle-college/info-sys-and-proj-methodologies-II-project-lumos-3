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
}
