public class CuttingBoard : Table, IInteractable
{
    public void Interact()
    {
        if (interactor.IsGrabbing)
        {
            Grabbable grabbingIngredient = interactor.GetGrabbingObject();

            if (grabbingIngredient.GetObjectType() == "Ingredient" && !ingredientOnTable)
            {
                // Put the ingredient on this table
                PutIngredient(grabbingIngredient.GetComponent<Ingredient>());
            }
        }

        else if (ingredientOnTable)
        {
            // Grab the ingredient on this table
            ingredientOnTable.transform.parent = null;
            ingredientOnTable.GetComponent<CursorFollower>().enabled = true;

            interactor.SetGrabbingObject(ingredientOnTable);

            ClearTable();
        }
    }
}
