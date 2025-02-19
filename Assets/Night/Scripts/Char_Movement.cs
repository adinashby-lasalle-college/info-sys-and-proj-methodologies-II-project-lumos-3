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
    private enum facing_Dir { Up,Down,Left,Right }
    facing_Dir current_dir;


    Char_FacingDir facing_dir_control;
    GameObject dirArrowObj;
    Char_DirArrow dirArrow;

    //Controller
    Char_InputTaker inputTaker;


    void Awake()
    {
        rb_player = GetComponent<Rigidbody2D>();
        facing_dir_control = GetComponent<Char_FacingDir>();
        dirArrowObj = GameObject.Find("Dir_Arrow_UI");
        dirArrow = dirArrowObj.GetComponent<Char_DirArrow>();
        inputTaker = GetComponent<Char_InputTaker>();
    }

    void Start()
    {
        rb_player.drag = drag;
        current_dir = facing_Dir.Right;
    }

    void Update()
    {
        //temporary**
        moveInput = inputTaker.GetMovementValue();
        UpdateCurrentDir();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void UpdateCurrentDir()
    {
        if (inputTaker.IsUpKeyPress())
        {
            current_dir = facing_Dir.Up;
        }
        else if (inputTaker.IsDownKeyPress())
        {
            current_dir = facing_Dir.Down;
        }
        else if (inputTaker.IsLeftKeyPress())
        {
            current_dir = facing_Dir.Left;
            facing_dir_control.ChangeCharFacing("Left");
        }
        else if (inputTaker.IsRightKeyPress())
        {
            current_dir = facing_Dir.Right;
            facing_dir_control.ChangeCharFacing("Right");
        }
        else { }


        if (inputTaker.IsUpKeyPress() || inputTaker.IsDownKeyPress() || inputTaker.IsLeftKeyPress() || inputTaker.IsRightKeyPress())
        {
            if (inputTaker.IsUpKeyPress())
            {
                current_dir = facing_Dir.Up;
            }
            else if (inputTaker.IsDownKeyPress())
            {
                current_dir = facing_Dir.Down;
            }
            else if (inputTaker.IsLeftKeyPress())
            {
                current_dir = facing_Dir.Left;
                facing_dir_control.ChangeCharFacing("Left");
            }
            else if (inputTaker.IsRightKeyPress())
            {
                current_dir = facing_Dir.Right;
                facing_dir_control.ChangeCharFacing("Right");
            }
        }

        dirArrow.SetArrowActive(current_dir.ToString());
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