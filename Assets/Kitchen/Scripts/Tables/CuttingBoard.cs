using UnityEngine;

public class CuttingBoard : Table, IInteractable
{
    [SerializeField] private Transform cuttingBoardTopTransform;
    [SerializeField] private CuttableIngredientSO[] cuttableIngredientSOList;

    private int sliceCount;
    private int sliceMaxCount = 3;

    public void Interact()
    {
        if (interactor.IsGrabbing)
        {
            Grabbable grabbingIngredient = interactor.GetGrabbingObject();

            if (grabbingIngredient.GetObjectType() == "Ingredient" && !ingredientOnTable)
            {
                // Check if the grabbing ingredient cuttable
                if (IsCuttable(grabbingIngredient))
                {
                    // Put the ingredient on this table
                    PutIngredient(grabbingIngredient.GetComponent<Ingredient>());
                }
            }
        }

        else if (ingredientOnTable)
        {
            if (sliceCount < sliceMaxCount)
            {
                Cut();
            }

            else
            {
                // Grab the ingredient on this table
                ingredientOnTable.transform.parent = null;
                ingredientOnTable.GetComponent<CursorFollower>().enabled = true;

                interactor.SetGrabbingObject(ingredientOnTable);

                ClearTable();

                sliceCount = 0;
            }
        }
    }

    private void Cut()
    {
        sliceCount++;
        
        if (sliceCount >= sliceMaxCount)
        {
            // Get sliced version ingredient
            IngredientSO slicedIngredientSO = GetSlicedIngredient(ingredientOnTable.GetIngredientSO());

            // Destroy the original ingredient
            ingredientOnTable.DestroySelf();

            // Put sliced ingredient on this cutting board
            Ingredient slicedIngredient = Ingredient.SpawnIngredient(slicedIngredientSO);
            PutOnCuttingBoard(slicedIngredient);
        }
    }

    private void PutOnCuttingBoard(Ingredient slicedIngredient)
    {
        if (slicedIngredient.GetComponent<CursorFollower>())
        {
            slicedIngredient.GetComponent<CursorFollower>().enabled = false;
        }

        slicedIngredient.transform.parent = cuttingBoardTopTransform;
        slicedIngredient.transform.localPosition = Vector3.zero;

        slicedIngredient.SetTable(this);
        ingredientOnTable = slicedIngredient;
    }

    private IngredientSO GetSlicedIngredient(IngredientSO ingredient)
    {
        // Find sliced version of the ingredient
        foreach (CuttableIngredientSO cuttableIngredientSO in cuttableIngredientSOList)
        {
            if (cuttableIngredientSO.originalIngredient == ingredient)
            {
                return cuttableIngredientSO.slicedIngredient;
            }
        }

        return null;
    }

    private bool IsCuttable(Grabbable ingredient)
    {
        IngredientSO ingredientSO = ingredient.GetComponent<Ingredient>().GetIngredientSO();

        foreach (CuttableIngredientSO cuttableIngredientSO in cuttableIngredientSOList)
        {
            if (cuttableIngredientSO.originalIngredient == ingredientSO)
            {
                return true;
            }
        }

        return false;
    }
}
