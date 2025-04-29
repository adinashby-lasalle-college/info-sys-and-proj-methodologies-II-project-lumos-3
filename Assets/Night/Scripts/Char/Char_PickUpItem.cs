using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_PickUpItem : MonoBehaviour
{
    [SerializeField] Transform DragPos;
    bool isPickableItemOverLapping;
    GameObject PickUpTarget;
    GameObject ItemInHand;
    bool isItemInHand;

    //UI for Pick up button
    UI_PickUpButton ui_PickUpButton;
    GameObject ui_ChargeButton;

    private void Start()
    {
        PickUpTarget = null;
        isItemInHand= false;
        ui_PickUpButton = GameObject.Find("PickUpKeyUI").GetComponent<UI_PickUpButton>();
        ui_ChargeButton = GameObject.Find("ChargeKeyUI");
        ui_ChargeButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<PickableItem>() != null)
        {
            isPickableItemOverLapping = true;
            PickUpTarget = collision.gameObject;
            if(ItemInHand == false)
            {
                ui_PickUpButton.ShowPickUpUI();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<PickableItem>() != null)
        {
            isPickableItemOverLapping = false;
            PickUpTarget = null;
            if (ItemInHand == false)
            {
                ui_PickUpButton.HidePickUpUI();
            }
        }
    }

    public bool IfPickableItemOverLapping()
    {
        return isPickableItemOverLapping;
    }

    public GameObject DragTarget()
    {
        gameObject.GetComponent<Char_Movement>().ReduceSpeed();
        isItemInHand = true;
        ItemInHand = PickUpTarget.GetComponentInParent<Rigidbody2D>().gameObject;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ItemInHand.GetComponent<Collider2D>(), true);
        ui_PickUpButton.HidePickUpUI();
        ui_ChargeButton.SetActive(true);
        return PickUpTarget;
    }

    public bool IfItemInHand()
    {
        return isItemInHand;
    }

    public void ThrowItemInHand(float Force)
    {
        ItemInHand.GetComponent<PickableItem>().ThrowThisItem(Force);
        gameObject.GetComponent<Char_Movement>().BackToNormalSpeed();
        isItemInHand = false;
        ui_ChargeButton.SetActive(false);
        StartCoroutine(SetBackCollider());
    }

    IEnumerator SetBackCollider()
    {
        yield return new WaitForSeconds(0.1f);
        if(ItemInHand != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ItemInHand.GetComponent<Collider2D>(), false);
        }
    }
}
