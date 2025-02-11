using UnityEngine;

public class Sauce : MonoBehaviour, IInteractable
{
    private SauceAnimator sauceAnimator;

    private void Start()
    {
        sauceAnimator = GetComponentInChildren<SauceAnimator>();    
    }

    private void OnMouseEnter()
    {
        sauceAnimator.TriggerAnimation("MoveUp");
    }

    private void OnMouseExit()
    {
        sauceAnimator.TriggerAnimation("MoveDown");
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }
}
