using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    public void ReadyToInteract()
    {
        // change cursor icon
        // opening animation
    }

    public void Interact()
    {
        // grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }

    public void EndInteract()
    {
        // closing animation

        Debug.Log("End interacting with " + this.name);
    }
}
