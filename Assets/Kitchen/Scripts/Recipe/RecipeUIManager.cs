using TMPro;
using UnityEngine;

public class RecipeUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeName;
    [SerializeField] private TextMeshProUGUI recipeText;
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private Animator animator;
    [SerializeField] private Bell bell;

    private void Start()
    {
        recipeManager.OnRecipeGenerated += UpdateRecipeUI;
        bell.OnServed += ClearRecipeUI;
    }

    public void UpdateRecipeUI(RecipeSO recipe)
    {
        recipeName.text = recipe.recipeName;

        foreach (IngredientSO ingredientSO in recipe.ingredientSOList)
        {
            recipeText.text += ingredientSO.ingredientName + "\n";
        }

        animator.SetTrigger("RecipeGenerated");
    }

    private void ClearRecipeUI()
    {
        recipeName.text = "";
        recipeText.text = "";

        animator.SetTrigger("Served");
    }
}
