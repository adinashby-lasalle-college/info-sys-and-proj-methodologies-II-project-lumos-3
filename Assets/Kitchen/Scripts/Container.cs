using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    [SerializeField] private IngredientSO ingredientSO;

    private AnimationManager animationPlayer;

    private void Start()
    {
        animationPlayer = GetComponentInChildren<AnimationManager>();
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
        if (!Interactor.Instance.IsGrabbing)
        {
            Ingredient ingredient = Ingredient.SpawnIngredient(ingredientSO);
            Interactor.Instance.SetGrabbingObject(ingredient);
        }
    }
}
