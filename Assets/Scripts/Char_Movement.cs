 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float maxSpeed = 5f;   
    public float drag = 5f;       

    private Rigidbody2D rb_player;
    private Vector2 moveInput;

    //Player's facing direction
    private enum facing_Dir { up,down,left,right }
    facing_Dir current_dir;

    //Visual
    Char_FacingDir facing_dir_control;


    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        facing_dir_control = GetComponent<Char_FacingDir>();
        rb_player.drag = drag;
        current_dir = facing_Dir.right;
    }

    void Update()
    {
        //temporary**
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * 0.3f).normalized;
        UpdateCurrentDir();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void UpdateCurrentDir()
    {
        //temporary**
        if (Input.GetKeyDown(KeyCode.W))
        {
            current_dir = facing_Dir.up;
            Debug.Log(current_dir);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            current_dir = facing_Dir.down;
            Debug.Log(current_dir);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            current_dir = facing_Dir.left;
            Debug.Log(current_dir);
            facing_dir_control.ChangeCharFacing("Left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            current_dir = facing_Dir.right;
            Debug.Log(current_dir);
            facing_dir_control.ChangeCharFacing("Right");
        }
        else { }


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                current_dir = facing_Dir.up;
                Debug.Log(current_dir);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                current_dir = facing_Dir.down;
                Debug.Log(current_dir);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                current_dir = facing_Dir.left;
                Debug.Log(current_dir);
                facing_dir_control.ChangeCharFacing("Left");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                current_dir = facing_Dir.right;
                Debug.Log(current_dir);
                facing_dir_control.ChangeCharFacing("Right");
            }
        }
   
    }

    void Movement()
    {
        //If the speed not reach the max, keep adding force
        if(moveInput != Vector2.zero)
        {
            if (rb_player.velocity.magnitude < maxSpeed)
            {
                rb_player.AddForce(moveInput * moveSpeed, ForceMode2D.Force);
            }
        }
        else
        {
            //when key release, stop the move immediately
            rb_player.velocity = Vector2.zero;
        }
    }
}