using UnityEngine;

[CreateAssetMenu()]
public class CookableIngredientSO : ScriptableObject
{
    public IngredientSO rawIngredient;
    public IngredientSO cookedIngredient;
    public IngredientSO burntIngredient;
}
