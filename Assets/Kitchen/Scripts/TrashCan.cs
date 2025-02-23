using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Destroy the grabbing ingredient
        if (Interactor.Instance.GetGrabbingIngredient())
        {
            Destroy(Interactor.Instance.GetGrabbingIngredient().gameObject);
            Interactor.Instance.ClearGrabbingIngredient();
        }
    }
}
