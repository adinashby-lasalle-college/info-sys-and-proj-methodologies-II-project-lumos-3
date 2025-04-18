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

            // Served
            OnServed?.Invoke();
            MoneyManager.Instance.AddMoney(priceManager.CalculatePrice(cookingTimer.CookTime));

            // Generate new recipe
            StartCoroutine(recipeManager.GenerateRecipe());
        }
        else
        {
            // If the recipe served is wrong, game over
            GameManager.Instance.GameOver();
        }

        prepTable.ClearPrepTable();
    }
}
