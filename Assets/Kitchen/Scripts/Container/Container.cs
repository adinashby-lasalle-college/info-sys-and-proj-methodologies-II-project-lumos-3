using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    private ContainerAnimator containerAnimator;

    private void Start()
    {
        containerAnimator = GetComponentInChildren<ContainerAnimator>();
    }

    private void OnMouseEnter()
    {
        containerAnimator.PlayOpenAnimation();
    }

    private void OnMouseExit()
    {
        containerAnimator.PlayCloseAnimation();
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }
}
