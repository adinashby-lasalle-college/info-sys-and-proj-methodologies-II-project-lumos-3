using UnityEngine;

public class Ingredient : Grabbable
{
    [SerializeField] private IngredientSO ingredientSO;

    private Table table; // Table where this ingredient is on

    public IngredientSO GetIngredientSO() { return ingredientSO; }

    public override string GetObjectType()
    {
        return "Ingredient";
    }

    public void SetTable(Table table)
    {
        this.table = table;
    }
}
