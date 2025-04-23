using System.Collections.Generic;
using UnityEngine;

public class PrepTable : Table, IInteractable
{
    public List<IngredientSO> ingredientSOList { get; private set; }

    private void Start()
    {
        ingredientSOList = new List<IngredientSO>();
    }

    public void Interact()
    {
        // If player is grabbing an object, put it on the table.
        if (Interactor.Instance.IsGrabbing)
        {
            switch (Interactor.Instance.GetGrabbingObject().GetObjectType())
            {
                case ObjectType.SAUCE:

                    Sauce sauce = Interactor.Instance.GetGrabbingObject().GetComponent<Sauce>();

                    // Create sauce prefab and add it on the table
                    Transform ingredientTransform = Instantiate(sauce.GetIngredientSO().prefab);
                    ingredientTransform.localPosition = Vector3.zero;

                    Ingredient ingredient = ingredientTransform.GetComponent<Ingredient>();
                    PutIngredient(ingredient);

                    // Ingredient dropping position will be slightly higher every time
                    tableTopTransform.localPosition = new Vector3(0, tableTopTransform.localPosition.y + 0.1f, 0);

                    // Put the sauce bottle back
                    sauce.PutSauceBottleBack();

                    // Add it to the ingredient list
                    ingredientSOList.Add(ingredient.GetIngredientSO());

                    break;

                case ObjectType.INGREDIENT_READY:
                case ObjectType.BUN:

                    ingredient = Interactor.Instance.GetGrabbingObject().GetComponent<Ingredient>();
                    PutIngredient(ingredient);

                    // Ingredient dropping position will be slightly higher every time
                    tableTopTransform.localPosition = new Vector3(0, tableTopTransform.localPosition.y + 0.1f, 0);

                    // Add it to the ingredient list
                    ingredientSOList.Add(ingredient.GetIngredientSO());

                    break;
            }
        }
    }

    public void ClearPrepTable()
    {
        ClearTable();
        
        // If there's something on the prep table, clear
        if (tableTopTransform.childCount > 0)
        {
            for (int i = 0; i < tableTopTransform.childCount; i++)
            {
                Destroy(tableTopTransform.GetChild(i).gameObject);
            }
        }

        ingredientSOList.Clear();
    }
}
