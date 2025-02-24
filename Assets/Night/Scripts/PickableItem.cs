using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    Rigidbody2D rb;
    bool IsThisObjectPicking;
    [SerializeField] Transform playerDragSpot;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        //IsThisObjectPicking = true;
        //rb.simulated = false;
        playerDragSpot = GameObject.Find("DragPos").GetComponent<Transform>();
    }

    //Object Move With Player After PickUp
    private void FixedUpdate()
    {
        if(IsThisObjectPicking)
        {
            this.transform.position = playerDragSpot.position;
        }
    }

    public void ThrowThisItem(string Dir, float Force)
    {
        float throwForce = 10f * Force;
        rb.velocity = Vector2.zero;
        if(Dir == "Up")
        {
            rb.AddForce(Vector2.up.normalized * throwForce, ForceMode2D.Impulse);
        }
        else if(Dir == "Down")
        {
            rb.AddForce(Vector2.down.normalized * throwForce, ForceMode2D.Impulse);
        }
        else if(Dir == "Left")
        {
            rb.AddForce(Vector2.left.normalized * throwForce, ForceMode2D.Impulse);
        }
        else if(Dir == "Right")
        {
            rb.AddForce(Vector2.right.normalized * throwForce, ForceMode2D.Impulse);
        }
        else
        {

        }
        IsThisObjectPicking = false;
        rb.simulated = true;
    }

    public void DragThisItem()
    {
        rb.simulated = false;
        IsThisObjectPicking = true;
    }
}
