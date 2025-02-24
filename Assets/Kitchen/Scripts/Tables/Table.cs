using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Transform tableTopTransform;

    protected Ingredient ingredientOnTable;
    protected Interactor interactor;

    public Ingredient GetIngredient() { return ingredientOnTable; }

    private void Start()
    {
        interactor = Interactor.Instance;
    }

    protected void PutIngredient(Ingredient ingredient)
    {
        if (ingredient.GetComponent<CursorFollower>())
        {
            ingredient.GetComponent<CursorFollower>().enabled = false;
        }

        ingredient.transform.parent = tableTopTransform;
        ingredient.transform.localPosition = Vector3.zero;

        // Ingredient dropping position will be slightly higher every time
        tableTopTransform.localPosition = new Vector3(0, tableTopTransform.localPosition.y + 0.2f, 0);

        ingredient.SetTable(this);
        ingredientOnTable = ingredient;

        interactor.ClearGrabbingObject();
    }

    protected void ClearTable()
    {
        ingredientOnTable.SetTable(null);
        ingredientOnTable = null;
    }
}
