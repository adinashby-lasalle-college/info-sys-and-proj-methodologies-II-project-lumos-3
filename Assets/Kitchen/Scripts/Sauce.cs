using UnityEngine;

public class Sauce : MonoBehaviour, IInteractable
{
    public void ReadyToInteract()
    {
        // * play moving up anim
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }

    public void EndInteract()
    {
        // * play moving down anim
    }
}
