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

    public void DestroySelf()
    {
        table.ClearTable();
        Destroy(gameObject);
    }

    public static Ingredient SpawnIngredient(IngredientSO ingredientSO)
    {
        Transform ingredientTransform = Instantiate(ingredientSO.prefab);
        ingredientTransform.localPosition = Vector3.zero;

        Ingredient ingredient = ingredientTransform.GetComponent<Ingredient>();

        return ingredient;
    }
}
