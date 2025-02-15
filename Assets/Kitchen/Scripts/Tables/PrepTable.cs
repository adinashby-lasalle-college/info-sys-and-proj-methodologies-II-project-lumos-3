public class PrepTable : Table, IInteractable
{
    public void Interact()
    {
        Ingredient grabbingIngredient = Interactor.Instance.GetGrabbingIngredient();

        // If player is grabbing an ingredient, put the ingredient on the table.
        if (grabbingIngredient)
        {
            PutIngredient(grabbingIngredient);

            Interactor.Instance.ClearGrabbingIngredient();
        }

        if (!grabbingIngredient && ingredientOnTable)
        {
            // * Grab the ingredient on this table
            
            ClearTable();
        }
    }
}
