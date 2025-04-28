using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckArea : MonoBehaviour
{
    public void DeliverNpc()
    {
        Debug.Log("Deliver NPC");
        AudioPlayer player = gameObject.GetComponent<AudioPlayer>();
        player.PlaySound(0);
    }
}
