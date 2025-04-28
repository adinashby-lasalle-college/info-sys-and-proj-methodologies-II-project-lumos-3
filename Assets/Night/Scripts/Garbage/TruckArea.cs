using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckArea : MonoBehaviour
{
    public void DeliverNpc()
    {
        Debug.Log("Deliver NPC");
        MoneyManager.Instance.AddMoney(5);
        AudioPlayer player = gameObject.GetComponent<AudioPlayer>();
        player.PlaySound(0);
    }
}
