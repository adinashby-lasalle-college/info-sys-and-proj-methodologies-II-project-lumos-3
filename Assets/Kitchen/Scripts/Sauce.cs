using UnityEngine;

public class Sauce : MonoBehaviour, IInteractable
{
    private AnimationManager animationPlayer;

    private void Start()
    {
        animationPlayer = GetComponentInChildren<AnimationManager>();    
    }

    private void OnMouseEnter()
    {
        animationPlayer.TriggerAnimation("MoveUp");
    }

    private void OnMouseExit()
    {
        animationPlayer.TriggerAnimation("MoveDown");
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }
}
