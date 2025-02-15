public class CuttingBoard : Table, IInteractable
{
    public void Interact()
    {
        Ingredient grabbingIngredient = Interactor.Instance.GetGrabbingIngredient();

        if (grabbingIngredient && !ingredientOnTable)
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
