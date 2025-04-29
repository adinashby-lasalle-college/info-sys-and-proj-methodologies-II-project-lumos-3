using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TruckArea : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] GameObject Partcle;

    public void DeliverNpc()
    {
        Debug.Log("Deliver NPC");
        MoneyManager.Instance.AddMoney(5);
        AudioPlayer player = gameObject.GetComponent<AudioPlayer>();
        player.PlaySound(0);
        Animator.Play("Deliver");
        StartCoroutine(DisplayParticle());

        GameObject Manager = GameObject.FindGameObjectWithTag("GameManager");
        if (Manager != null)
        {
            //Game Over
            Manager.GetComponent<NewsPaperGenerator>().SwitchNews(3);
        }
    }

    IEnumerator DisplayParticle()
    {
        Partcle.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Partcle.SetActive(false);
    }
}
