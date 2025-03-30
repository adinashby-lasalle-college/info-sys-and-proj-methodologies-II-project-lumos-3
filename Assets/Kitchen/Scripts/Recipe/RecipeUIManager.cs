using TMPro;
using UnityEngine;

public class RecipeUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipeName;
    [SerializeField] private TextMeshProUGUI recipeText;

    public void UpdateRecipeUI(RecipeSO recipe)
    {
        ClearRecipeUI();

        recipeName.text = recipe.recipeName;

        foreach (IngredientSO ingredientSO in recipe.ingredientSOList)
        {
            recipeText.text += ingredientSO.ingredientName + "\n";
        }
    }

    private void ClearRecipeUI()
    {
        recipeName.text = "";
        recipeText.text = "";
    }
}
