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

    public void ThrowThisItem(float Force)
    {
        Char_Movement player = GameObject.FindGameObjectWithTag("Player").GetComponent<Char_Movement>();
        string Dir = player.GetCurrentDirection();
        float throwForce = 1500f * Force;
        Debug.Log(throwForce.ToString());
        rb.velocity = Vector2.zero;
        if(Dir == "Up")
        {
            rb.AddForce(Vector2.up * throwForce);
            Debug.Log("Up");
        }
        else if(Dir == "Down")
        {
            rb.AddForce(Vector2.down * throwForce);
            Debug.Log("Down");
        }
        else if(Dir == "Left")
        {
            rb.AddForce(Vector2.left * throwForce);
            Debug.Log("Left");
        }
        else if(Dir == "Right")
        {
            rb.AddForce(Vector2.right * throwForce);
            Debug.Log("Right");
        }
        else
        {

        }
        IsThisObjectPicking = false;
    }

    public void DragThisItem()
    {
        IsThisObjectPicking = true;
    }
}
