using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, I_PickableObj
{
    Rigidbody2D rb;
    public bool IsThisObjectPicking;
    [SerializeField] Transform playerDragSpot;
    AudioPlayer SEPlayer;

    private void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        playerDragSpot = GameObject.Find("DragPos").GetComponent<Transform>();
        SEPlayer = GetComponent<AudioPlayer>();
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
        float throwForce = 10000f * Force;
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
        SEPlayer.PlaySound(0);
        IsThisObjectPicking = false;
    }

    public void DragThisItem()
    {
        IsThisObjectPicking = true;
    }
}
