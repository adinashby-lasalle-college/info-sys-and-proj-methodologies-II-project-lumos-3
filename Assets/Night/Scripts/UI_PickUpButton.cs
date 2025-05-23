using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PickUpButton : FollowUpUI
{
    //A button will display if player got item can be pick up in range
    public Vector3 Offset;
    GameObject player;
    [SerializeField] GameObject PickUpButtonUI;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetTarget(player.transform, Offset);
        HidePickUpUI();
    }

    public void ShowPickUpUI()
    {
        if (PickUpButtonUI != null)
        {
            PickUpButtonUI.SetActive(true);
        }
    }

    public void HidePickUpUI()
    {
        if(PickUpButtonUI != null)
        {
            PickUpButtonUI.SetActive(false);
        }
    }
}
