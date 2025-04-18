using System;
using System.Collections;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeListSO;
    [SerializeField] private RecipeUIManager recipeUIManager;
    [SerializeField] private CookingTimer cookingTimer;

    private float coolTime = 3f; // cooltime to generate new recipe

    public event Action<RecipeSO> OnRecipeGenerated;

    public RecipeSO CurrRecipe { get; private set; }

    private void Start()
    {
        StartCoroutine(GenerateRecipe());
    }

    public IEnumerator GenerateRecipe()
    {
        yield return new WaitForSeconds(coolTime);

        CurrRecipe = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];

        OnRecipeGenerated?.Invoke(CurrRecipe);

        // Start timer
        cookingTimer.StartTimer();
    }
}
