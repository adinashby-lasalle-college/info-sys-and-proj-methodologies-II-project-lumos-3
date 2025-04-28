using System;
using UnityEngine;

public class Bell : MonoBehaviour, IInteractable
{
    [SerializeField] private PriceManager priceManager;
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private CookingTimer cookingTimer;
    [SerializeField] private PrepTable prepTable;

    public event Action OnServed;

    public void Interact()
    {
        Serve();
    }

    public void Serve()
    {
        // If there's any ingredient on the prep table
        if (prepTable.ingredientSOList.Count > 0)
        {
            // If a recipe is not generated, ignore
            if (!recipeManager.CurrRecipe)
            {
                return;
            }

            // Check if the ingredient counts are the same
            if (recipeManager.CurrRecipe.ingredientSOList.Count == prepTable.ingredientSOList.Count)
            {
                for (int i = 0; i < prepTable.ingredientSOList.Count; i++)
                {
                    if (recipeManager.CurrRecipe.ingredientSOList[i] != prepTable.ingredientSOList[i])
                    {
                        GameManager.Instance.GameOver();
                    }
                }

                MoneyManager.Instance.AddMoney(priceManager.CalculatePrice(cookingTimer.CookTime));

                // Served
                OnServed?.Invoke();

                // Generate new recipe
                StartCoroutine(recipeManager.GenerateRecipe());
            }
            else
            {
                // If the recipe served is wrong, game over
                GameManager.Instance.GameOver();
            }
        }

        prepTable.ClearPrepTable();
    }
}
