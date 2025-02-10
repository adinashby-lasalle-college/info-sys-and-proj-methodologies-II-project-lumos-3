using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    private ContainerAnimator animator;
    

    private void Start()
    {
        animator = GetComponent<ContainerAnimator>();
    }

    public void ReadyToInteract()
    {
        // * change cursor icon

        animator.PlayOpenAnimation(this);
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }

    public void EndInteract()
    {
        animator.PlayCloseAnimation(this);
    }
}
