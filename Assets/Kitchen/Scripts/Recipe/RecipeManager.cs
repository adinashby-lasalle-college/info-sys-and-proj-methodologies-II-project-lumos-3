using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeListSO;
    [SerializeField] private RecipeUIManager recipeUIManager;

    public RecipeSO CurrRecipe { get; private set; }

    private void Start()
    {
        // ** INSTANT CODE
        GenerateRecipe();
    }

    public void GenerateRecipe()
    {
        CurrRecipe = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];

        recipeUIManager.UpdateRecipeUI(CurrRecipe);

        // Start timer
        CookingTimer.Instance.StartTimer();
    }
}
