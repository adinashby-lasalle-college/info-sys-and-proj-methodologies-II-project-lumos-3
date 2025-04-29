using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckArea : MonoBehaviour
{
    [SerializeField] Animator Animator;

    public void DeliverNpc()
    {
        Debug.Log("Deliver NPC");
        //MoneyManager.Instance.AddMoney(5);
        AudioPlayer player = gameObject.GetComponent<AudioPlayer>();
        player.PlaySound(0);
        Animator.Play("Deliver");

        GameObject Manager = GameObject.FindGameObjectWithTag("GameManager");
        if (Manager != null)
        {
            //Game Over
            Manager.GetComponent<NewsPaperGenerator>().SwitchNews(3);
        }
    }
}
