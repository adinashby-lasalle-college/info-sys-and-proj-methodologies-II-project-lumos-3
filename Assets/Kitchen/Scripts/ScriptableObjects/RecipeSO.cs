using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public List<IngredientSO> ingredientSOList;
    public string recipeName;
    public int additionalPrice;
}
