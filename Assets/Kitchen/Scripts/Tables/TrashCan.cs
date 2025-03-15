using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Destroy the grabbing ingredient
        if (Interactor.Instance.GetGrabbingObject())
        {
            Destroy(Interactor.Instance.GetGrabbingObject().gameObject);
            Interactor.Instance.ClearGrabbingObject();
        }
    }
}
