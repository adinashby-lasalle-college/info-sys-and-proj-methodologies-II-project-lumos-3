using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] protected Transform tableTopTransform;

    private Vector3 originalTopPos; // original table top position;
    protected Ingredient ingredientOnTable;
    protected Interactor interactor;

    private void Awake()
    {
        originalTopPos = tableTopTransform.localPosition;
    }

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

            tableTopTransform.localPosition = originalTopPos;
        }
    }
}
