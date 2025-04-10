using System;
using UnityEngine;

public class Bell : MonoBehaviour, IInteractable
{
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private PrepTable prepTable;

    public static Bell Instance { get; private set; }

    public event Action<int> OnServed;

    private void Awake()
    {
        Instance = this;
    }

    public void Interact()
    {
        Serve();
    }

    public void Serve()
    {
        // Check if the ingredient counts are the same
        if (recipeManager.CurrRecipe.ingredientSOList.Count == prepTable.ingredientSOList.Count)
        {
            // ** Order for CurrRecipe should be the opposite
            for (int i = 0; i < prepTable.ingredientSOList.Count; i++)
            {
                if (recipeManager.CurrRecipe.ingredientSOList[i] != prepTable.ingredientSOList[i])
                {
                    Debug.Log("fail");
                    // * Game Over
                    return;
                }
            }

            Debug.Log("recipe matches");

            // Served
            OnServed?.Invoke(PriceManager.Instance.CalculatePrice(CookingTimer.Instance.CookTime));

            // Generate new recipe
            StartCoroutine(recipeManager.GenerateRecipe());
        }
        else
        {
            Debug.Log("fail");
            // * Game Over
        }

        prepTable.ClearPrepTable();
    }
}
