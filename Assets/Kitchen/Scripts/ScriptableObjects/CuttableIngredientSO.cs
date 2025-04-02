using UnityEngine;

[CreateAssetMenu()]
public class CuttableIngredientSO : ScriptableObject
{
    public IngredientSO originalIngredient;
    public IngredientSO slicedIngredient;
}
