using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeListSO;

    public RecipeSO CurrRecipe { get; private set; }

    private void Start()
    {
        // ** INSTANT CODE
        GenerateRecipe();
    }

    public void GenerateRecipe()
    {
        CurrRecipe = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];

        Debug.Log("Recipe: ");
        foreach (IngredientSO ingredientSO in CurrRecipe.ingredientSOList)
        {
            Debug.Log(ingredientSO.name);
        }

        // Start timer
        CookingTimer.Instance.StartTimer();
    }
}
