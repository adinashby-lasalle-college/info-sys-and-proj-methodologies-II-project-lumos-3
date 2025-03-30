using UnityEngine;

public class HighPriceHandler : PriceHandler
{
    private float highPriceTimeLimit = 15f;

    public override void HandleRequest(float cookTime)
    {
        if (cookTime < highPriceTimeLimit)
        {
            Debug.Log("price: 15$");
        }
        else if (nextHandler)
        {
            nextHandler.HandleRequest(cookTime);
        }
    }
}
