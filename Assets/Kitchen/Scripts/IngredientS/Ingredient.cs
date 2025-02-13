using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private IngredientSO ingredientSO;

    private Table table; // Table where this ingredient is on

    public IngredientSO GetIngredientSO() { return ingredientSO; }

    public void SetTable(Table table)
    {
        this.table = table;
    }
}
