using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_PickUpItem : MonoBehaviour
{
    [SerializeField] Transform DragPos;
    bool isPickableItemOverLapping;
    GameObject PickUpTarget;

    private void Start()
    {
        PickUpTarget = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PickableItem>() != null)
        {
            Debug.Log("Enter");
            isPickableItemOverLapping = true;
            PickUpTarget = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PickableItem>() != null)
        {
            Debug.Log("Exit");
            isPickableItemOverLapping = false;
            PickUpTarget = null;
        }
    }

    public bool IfPickableItemOverLapping()
    {
        return isPickableItemOverLapping;
    }

    public GameObject DragTarget()
    {
        return PickUpTarget;
    }
}
