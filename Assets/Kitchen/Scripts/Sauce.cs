using UnityEngine;

public class Sauce : MonoBehaviour, IInteractable
{
    private void OnMouseEnter()
    {
        //animator.PlayOpenAnimation(this);
    }

    private void OnMouseExit()
    {
        //animator.PlayCloseAnimation(this);
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }
}
