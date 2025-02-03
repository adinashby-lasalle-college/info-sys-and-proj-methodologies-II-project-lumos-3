using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private KitchenInputActions kitchenInputActions;

    public event EventHandler OnInteractAction;

    private void Awake()
    {
        kitchenInputActions = new KitchenInputActions();

        kitchenInputActions.Camera.Enable();
        kitchenInputActions.Player.Enable();

        kitchenInputActions.Player.Interact.performed += TryInteract;
    }

    // * Observer Pattern *
    private void TryInteract(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // If there's at least one listener, invoke the event
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public float GetZInput()
    {
        return kitchenInputActions.Camera.Move.ReadValue<float>();
    }
}
