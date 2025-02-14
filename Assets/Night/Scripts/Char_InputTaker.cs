using PlayerAction_NightEvent;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Char_InputTaker : MonoBehaviour
{
    Vector2 Movement;

    NightEventInput playerAction;

    void Awake()
    {
        playerAction= new NightEventInput();
    }

    //Movement Input taker
    private void OnMovement(InputValue value)
    {
        Vector2 RawValue = value.Get<Vector2>();
        Movement = new Vector2(RawValue.x, RawValue.y*0.5f);
    }
    //Get Movement
    public Vector2 GetMovementValue()
    {
        return Movement;
    }

    //Direction change Input taker
    void OnEnable()
    {
        //Setting key's Perform and Cancel
        playerAction.InGame.ChangeDir_Up.performed += OnChangeDir_Up_Press;
        playerAction.InGame.ChangeDir_Up.Enable();

        playerAction.InGame.ChangeDir_Down.performed += OnChangeDir_Down_Press;
        playerAction.InGame.ChangeDir_Down.Enable();

        playerAction.InGame.ChangeDir_Left.performed += OnChangeDir_Left_Press;
        playerAction.InGame.ChangeDir_Left.Enable();

        playerAction.InGame.ChangeDir_Right.performed += OnChangeDir_Right_Press;
        playerAction.InGame.ChangeDir_Right.Enable();

        playerAction.InGame.ChangeDir_Up.canceled += OnChangeDir_Up_Release;
        playerAction.InGame.ChangeDir_Up.Enable();

        playerAction.InGame.ChangeDir_Down.canceled += OnChangeDir_Down_Release;
        playerAction.InGame.ChangeDir_Down.Enable();

        playerAction.InGame.ChangeDir_Left.canceled += OnChangeDir_Left_Release;
        playerAction.InGame.ChangeDir_Left.Enable();

        playerAction.InGame.ChangeDir_Right.canceled += OnChangeDir_Right_Release;
        playerAction.InGame.ChangeDir_Right.Enable();
    }

    void OnDisable()
    {
        playerAction.InGame.ChangeDir_Up.performed -= OnChangeDir_Up_Press;
        playerAction.InGame.ChangeDir_Up.Disable();

        playerAction.InGame.ChangeDir_Down.performed -= OnChangeDir_Down_Press;
        playerAction.InGame.ChangeDir_Down.Disable();

        playerAction.InGame.ChangeDir_Left.performed -= OnChangeDir_Left_Press;
        playerAction.InGame.ChangeDir_Left.Disable();

        playerAction.InGame.ChangeDir_Right.performed -= OnChangeDir_Right_Press;
        playerAction.InGame.ChangeDir_Right.Disable();

        playerAction.InGame.ChangeDir_Up.canceled -= OnChangeDir_Up_Release;
        playerAction.InGame.ChangeDir_Up.Disable();

        playerAction.InGame.ChangeDir_Down.canceled -= OnChangeDir_Down_Release;
        playerAction.InGame.ChangeDir_Down.Disable();

        playerAction.InGame.ChangeDir_Left.canceled -= OnChangeDir_Left_Release;
        playerAction.InGame.ChangeDir_Left.Disable();

        playerAction.InGame.ChangeDir_Right.canceled -= OnChangeDir_Right_Release;
        playerAction.InGame.ChangeDir_Right.Disable();
    }


    bool UpKeyPress;
    bool DownKeyPress;
    bool LeftKeyPress;
    bool RightKeyPress;

    void OnChangeDir_Up_Press(InputAction.CallbackContext context)
    {
        UpKeyPress = true;
    }

    void OnChangeDir_Down_Press(InputAction.CallbackContext context)
    {
        DownKeyPress= true;
    }

    void OnChangeDir_Left_Press(InputAction.CallbackContext context)
    {
        LeftKeyPress= true;
    }

    void OnChangeDir_Right_Press(InputAction.CallbackContext context)
    {
        RightKeyPress= true;
    }

    void OnChangeDir_Up_Release(InputAction.CallbackContext context)
    {
        UpKeyPress = false;
    }

    void OnChangeDir_Down_Release(InputAction.CallbackContext context)
    {
        DownKeyPress = false;
    }

    void OnChangeDir_Left_Release(InputAction.CallbackContext context)
    {
        LeftKeyPress = false;
    }

    void OnChangeDir_Right_Release(InputAction.CallbackContext context)
    {
        RightKeyPress = false;
    }

    //Getter
    public bool IsUpKeyPress()
    {
        return UpKeyPress;
    }

    public bool IsDownKeyPress()
    {
        return DownKeyPress;
    }

    public bool IsLeftKeyPress()
    {
        return LeftKeyPress;
    }

    public bool IsRightKeyPress()
    {
        return RightKeyPress;
    }


}
