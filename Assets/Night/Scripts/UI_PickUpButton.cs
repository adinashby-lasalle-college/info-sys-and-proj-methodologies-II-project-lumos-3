using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PickUpButton : FollowUpUI
{
    //A button will display if player got item can be pick up in range
    public Vector3 Offset;
    public GameObject player;
    [SerializeField] GameObject PickUpButtonUI;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetTarget(player.transform, Offset);
    }

    public void ShowPickUpUI()
    {
        PickUpButtonUI.SetActive(true);
    }

    public void HidePickUpUI()
    {
        PickUpButtonUI?.SetActive(false);
    }
}
