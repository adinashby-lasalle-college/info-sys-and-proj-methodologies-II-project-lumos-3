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

    private void Start()
    {
        PickUpTarget = null;
        isItemInHand= false;
        ui_PickUpButton = GameObject.Find("PickUpKeyUI").GetComponent<UI_PickUpButton>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<PickableItem>() != null)
        {
            isPickableItemOverLapping = true;
            PickUpTarget = collision.gameObject;
            ui_PickUpButton.ShowPickUpUI();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponentInParent<PickableItem>() != null)
        {
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
        gameObject.GetComponent<Char_Movement>().ReduceSpeed();
        isItemInHand = true;
        ItemInHand = PickUpTarget.GetComponentInParent<Rigidbody2D>().gameObject;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ItemInHand.GetComponent<Collider2D>(), true);
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
        StartCoroutine(SetBackCollider());
    }

    IEnumerator SetBackCollider()
    {
        yield return new WaitForSeconds(0.2f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), ItemInHand.GetComponent<Collider2D>(), false);
    }
}
