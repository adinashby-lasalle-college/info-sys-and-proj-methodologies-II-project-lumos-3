public class HighPriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        if (cookTime < priceManager.GetHighPriceTimeLimit())
        {
            priceManager.SetPrice(priceManager.GetHighPrice());
        }
        else if (nextHandler)
        {
            nextHandler.HandleRequest(cookTime);
        }
    }
}
