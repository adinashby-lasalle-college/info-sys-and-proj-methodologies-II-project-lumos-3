using System.Drawing;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private IngredientSO ingredientSO;

    public IngredientSO GetIngredientSO() { return ingredientSO; }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane + 1));

        transform.position = mousePos;
    }
}
