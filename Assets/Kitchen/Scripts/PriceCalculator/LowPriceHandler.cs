public class LowPriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        priceManager.SetPrice(priceManager.GetLowPrice());
    }
}
