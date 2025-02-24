using UnityEngine;

public class PrepTable : Table, IInteractable
{
    private void Start()
    {
        interactor = Interactor.Instance;
    }

    public void Interact()
    {
        // If player is grabbing an object, put it on the table.
        if (interactor.IsGrabbing)
        {
            switch (interactor.GetGrabbingObject().GetObjectType())
            {
                case "Sauce":

                    Sauce sauce = interactor.GetGrabbingObject().GetComponent<Sauce>();

                    // Create sauce prefab and add it on the table
                    Transform ingredientTransform = Instantiate(sauce.GetIngredientSO().prefab);
                    ingredientTransform.localPosition = Vector3.zero;

                    Ingredient ingredient = ingredientTransform.GetComponent<Ingredient>();
                    PutIngredient(ingredient);

                    // * Put the sauce bottle back
                    // * Clear the grabbing object at Interactor

                    break;

                case "Ingredient":

                    ingredient = interactor.GetGrabbingObject().GetComponent<Ingredient>();
                    PutIngredient(ingredient);

                    break;
            }
        }

        if (!interactor.IsGrabbing && ingredientOnTable)
        {
            // * Grab the ingredient on this table
            
            ClearTable();
        }
    }
}
