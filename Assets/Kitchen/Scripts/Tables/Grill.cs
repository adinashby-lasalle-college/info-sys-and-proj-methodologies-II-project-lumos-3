public class Grill : Table, IInteractable
{
    public void Interact()
    {
        Ingredient grabbingIngredient = Interactor.Instance.GetGrabbingIngredient();

        // Put an ingredient on this table
        if (grabbingIngredient && !ingredientOnTable)
        {
            PutIngredient(grabbingIngredient);

            Interactor.Instance.ClearGrabbingIngredient();
        }

        // Pick up the ingredient on this table
        if (!grabbingIngredient && ingredientOnTable)
        {
            // * Grab the ingredient on this table

            ClearTable();
        }
    }
}
