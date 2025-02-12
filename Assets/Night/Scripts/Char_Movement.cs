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
        dirArrowObj = GameObject.Find("Dir_Arrow");
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
        moveInput = inputTaker.Movement;
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
            current_dir = facing_Dir.Up;
            Debug.Log(current_dir);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            current_dir = facing_Dir.Down;
            Debug.Log(current_dir);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            current_dir = facing_Dir.Left;
            Debug.Log(current_dir);
            facing_dir_control.ChangeCharFacing("Left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            current_dir = facing_Dir.Right;
            Debug.Log(current_dir);
            facing_dir_control.ChangeCharFacing("Right");
        }
        else { }


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                current_dir = facing_Dir.Up;
                Debug.Log(current_dir);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                current_dir = facing_Dir.Down;
                Debug.Log(current_dir);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                current_dir = facing_Dir.Left;
                Debug.Log(current_dir);
                facing_dir_control.ChangeCharFacing("Left");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                current_dir = facing_Dir.Right;
                Debug.Log(current_dir); 
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