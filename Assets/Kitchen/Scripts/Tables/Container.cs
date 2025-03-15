using UnityEngine;

public class Container : MonoBehaviour, IInteractable
{
    [SerializeField] private IngredientSO ingredientSO;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMouseEnter()
    {
        animator.SetTrigger("Open");
    }

    private void OnMouseExit()
    {
        animator.SetTrigger("Close");
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
