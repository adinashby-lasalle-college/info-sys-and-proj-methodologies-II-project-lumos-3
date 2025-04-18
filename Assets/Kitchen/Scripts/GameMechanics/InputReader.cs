using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public static InputReader Instance { get; private set; }

    private KitchenInputActions kitchenInputActions;

    public event EventHandler OnInteractAction;
    public event EventHandler OnCutAction;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }

        kitchenInputActions = new KitchenInputActions();

        kitchenInputActions.Camera.Enable();
        kitchenInputActions.Player.Enable();

        kitchenInputActions.Player.Interact.performed += TryInteract;
        kitchenInputActions.Player.Cut.performed += TryCut;
    }

    private void OnDisable()
    {
        kitchenInputActions.Player.Interact.performed -= TryInteract;
        kitchenInputActions.Player.Cut.performed -= TryCut;
    }

    private void TryCut(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnCutAction?.Invoke(this, EventArgs.Empty);
    }

    private void TryInteract(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // If there's at least one listener, invoke the event
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public float GetZInput()
    {
        return kitchenInputActions.Camera.Move.ReadValue<float>();
    }

    public Vector2 GetCursorPos()
    {
        return kitchenInputActions.Player.Cursor.ReadValue<Vector2>();
    }
}
