using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] protected Transform tableTopTransform;

    protected Ingredient ingredientOnTable;
    protected Interactor interactor;

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

        ingredient.SetTable(this);
        ingredientOnTable = ingredient;

        interactor.ClearGrabbingObject();
    }

    public void ClearTable()
    {
        if (ingredientOnTable)
        {
            ingredientOnTable.SetTable(null);
            ingredientOnTable = null;
        }
    }
}
