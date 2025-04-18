public class MiddlePriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        if (cookTime < priceManager.GetMiddlePriceTimeLimit())
        {
            priceManager.SetPrice(priceManager.GetMiddlePrice());
        }
        else if (nextHandler)
        {
            nextHandler.HandleRequest(cookTime);
        }
    }
}
