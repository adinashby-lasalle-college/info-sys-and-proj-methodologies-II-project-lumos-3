using UnityEngine;

public class MiddlePriceHandler : PriceHandler
{
    private float middlePriceTimeLimit = 25f;

    public override void HandleRequest(float cookTime)
    {
        if (cookTime < middlePriceTimeLimit)
        {
            Debug.Log("price: 10$");
        }
        else if (nextHandler)
        {
            nextHandler.HandleRequest(cookTime);
        }
    }
}
