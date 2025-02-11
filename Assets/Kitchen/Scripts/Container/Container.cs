using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    private AnimationPlayer animationPlayer;

    private void Start()
    {
        animationPlayer = GetComponentInChildren<AnimationPlayer>();
    }

    private void OnMouseEnter()
    {
        animationPlayer.TriggerAnimation("Open");
    }

    private void OnMouseExit()
    {
        animationPlayer.TriggerAnimation("Close");
    }

    public void Interact()
    {
        // * grab an ingredient

        Debug.Log("Interacting with " + this.name);
    }
}
