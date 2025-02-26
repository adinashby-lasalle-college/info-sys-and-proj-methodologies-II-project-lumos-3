using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_PickUpItem : MonoBehaviour
{
    [SerializeField] Transform DragPos;
    bool isPickableItemOverLapping;
    GameObject PickUpTarget;
    bool isItemInHand;

    //UI for Pick up button
    UI_PickUpButton ui_PickUpButton;

    private void Start()
    {
        PickUpTarget = null;
        isItemInHand= false;
        ui_PickUpButton = GameObject.Find("PickUpKeyUI").GetComponent<UI_PickUpButton>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickableItem>() != null)
        {
            Debug.Log("Enter");
            isPickableItemOverLapping = true;
            PickUpTarget = collision.gameObject;
            ui_PickUpButton.ShowPickUpUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickableItem>() != null)
        {
            Debug.Log("Exit");
            isPickableItemOverLapping = false;
            PickUpTarget = null;
            ui_PickUpButton.HidePickUpUI();
        }
    }

    public bool IfPickableItemOverLapping()
    {
        return isPickableItemOverLapping;
    }

    public GameObject DragTarget()
    {
        Char_Movement movement = gameObject.GetComponent<Char_Movement>();
        movement.ReduceSpeed();
        isItemInHand = true;
        Debug.Log("Drag");
        return PickUpTarget;
    }

    public bool IfItemInHand()
    {
        return isItemInHand;
    }
}
