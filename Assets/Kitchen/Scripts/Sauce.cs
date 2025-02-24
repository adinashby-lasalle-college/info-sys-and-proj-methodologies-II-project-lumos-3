using UnityEngine;

public class Sauce : Grabbable, IInteractable
{
    [SerializeField] private IngredientSO sauceSO;

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
        // Grab this sauce bottle
        if (!Interactor.Instance.IsGrabbing)
        {
            GetComponent<CursorFollower>().enabled = true;
            Interactor.Instance.SetGrabbingObject(this);
        }
    }

    public override string GetObjectType()
    {
        return "Sauce";
    }

    public IngredientSO GetIngredientSO()
    {
        return sauceSO; 
    }
}
