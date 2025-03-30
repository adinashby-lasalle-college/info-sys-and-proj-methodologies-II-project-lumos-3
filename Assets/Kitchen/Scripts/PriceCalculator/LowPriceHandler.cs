using UnityEngine;

public class LowPriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        Debug.Log("price: 5$");
    }
}
