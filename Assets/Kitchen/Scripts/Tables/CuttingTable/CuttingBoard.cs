using UnityEngine;

public class CuttingBoard : Table, IInteractable
{
    [SerializeField] private Transform cuttingBoardTopTransform;
    [SerializeField] private CuttableIngredientSO[] cuttableIngredientSOList;

    private float sliceCount;
    private float sliceMaxCount = 3f;

    public void Interact()
    {
        if (Interactor.Instance.IsGrabbing)
        {
            Grabbable grabbingIngredient = Interactor.Instance.GetGrabbingObject();

            // If the grabbing object is cuttable,
            if (grabbingIngredient.GetObjectType() == ObjectType.CUTTABLE && !ingredientOnTable)
            {
                // Put it on this table
                PutIngredient(grabbingIngredient.GetComponent<Ingredient>());
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

                Interactor.Instance.SetGrabbingObject(ingredientOnTable);

                ClearTable();

                sliceCount = 0;
            }

            // Update UI & play SFX
            CuttingEffectManager.GetInstance().UpdateEffect(sliceCount, sliceMaxCount);
        }
    }

    private void Cut()
    {
        sliceCount++;

        if (sliceCount >= sliceMaxCount)
        {
            // Get sliced version ingredient
            IngredientSO slicedIngredientSO = GetSlicedIngredientSO(ingredientOnTable.GetIngredientSO());

            // Destroy the original ingredient
            ingredientOnTable.DestroySelf();

            // Put sliced ingredient on this cutting board
            Ingredient slicedIngredient = Ingredient.SpawnIngredient(slicedIngredientSO);
            PutSlicedIngredient(slicedIngredient);
        }
    }

    private void PutSlicedIngredient(Ingredient slicedIngredient)
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

    private IngredientSO GetSlicedIngredientSO(IngredientSO ingredient)
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
}
