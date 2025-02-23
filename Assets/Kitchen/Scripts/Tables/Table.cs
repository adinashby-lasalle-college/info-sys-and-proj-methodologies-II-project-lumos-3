using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Transform tableTopTransform;

    protected Ingredient ingredientOnTable;

    public Ingredient GetIngredient() { return ingredientOnTable; }

    protected void PutIngredient(Ingredient ingredient)
    {
        ingredient.GetComponent<CursorFollower>().enabled = false;
        ingredient.transform.parent = tableTopTransform;
        ingredient.transform.localPosition = Vector3.zero;

        tableTopTransform.localPosition = new Vector3(0, tableTopTransform.localPosition.y + 0.2f, 0);

        ingredient.SetTable(this);
        ingredientOnTable = ingredient;
    }

    protected void ClearTable()
    {
        ingredientOnTable.SetTable(null);
        ingredientOnTable = null;
    }
}
