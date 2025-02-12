using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Char_InputTaker : MonoBehaviour
{
    public Vector2 Movement;

     private void OnMovement(InputValue value)
    {
        Movement = value.Get<Vector2>();
        Debug.Log(value.ToString());
    }
}
