using UnityEngine;

public class BunContainer : Container
{
    [SerializeField] private IngredientSO bottomBunSO;
    [SerializeField] private IngredientSO topBunSO;

    private bool isBottomBreadTaken;

    public void SwitchBun()
    {
        if (isBottomBreadTaken)
        {
            ingredientSO = topBunSO;
            isBottomBreadTaken = false;
        }
        else
        {
            ingredientSO = bottomBunSO;
            isBottomBreadTaken = true;
        }
    }
}
