public class CuttingBoard : Table, IInteractable
{
    public void Interact()
    {
        Ingredient grabbingIngredient = interactor.GetGrabbingIngredient();

        if (grabbingIngredient && !ingredientOnTable)
        {
            // Put the ingredient on this table
            PutIngredient(grabbingIngredient);

            interactor.ClearGrabbingIngredient();
        }

        if (!grabbingIngredient && ingredientOnTable)
        {
            // Grab the ingredient on this table
            interactor.SetGrabbingIngredient(ingredientOnTable);

            grabbingIngredient = interactor.GetGrabbingIngredient();
            grabbingIngredient.transform.parent = null;
            grabbingIngredient.GetComponent<CursorFollower>().enabled = true;

            ClearTable();
        }
    }
}
