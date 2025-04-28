using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Grabbable grabbingObject = Interactor.Instance.GetGrabbingObject();

        // Destroy the grabbing ingredient
        if (grabbingObject)
        {
            if (grabbingObject.GetObjectType() == ObjectType.SAUCE)
            {
                grabbingObject.GetComponent<Sauce>().PutSauceBottleBack();
            }
            else
            {
                Destroy(Interactor.Instance.GetGrabbingObject().gameObject);
                KitchenSFXManager.Instance.PlayThrowSound();
            }

            Interactor.Instance.ClearGrabbingObject();
        }
    }
}
