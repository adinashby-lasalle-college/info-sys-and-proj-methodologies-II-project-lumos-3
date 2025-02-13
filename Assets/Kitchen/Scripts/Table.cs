using UnityEngine;

public class Table : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform tableTopTransform;

    private Ingredient ingredient;

    public void Interact()
    {
        Ingredient ingredient = Interactor.Instance.GetGrabbingIngredient();

        if (ingredient)
        {
            // If player is grabbing an ingredient, put it on this table.
            ingredient.GetComponent<CursorFollower>().enabled = false;
            ingredient.transform.parent = tableTopTransform;
            ingredient.transform.localPosition = Vector3.zero;

            // Clear grabbing ingredient
            Interactor.Instance.ClearGrabbingIngredient();
        }
    }
}
