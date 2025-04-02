public class LowPriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        PriceManager.Instance.SetPrice(PriceManager.Instance.GetLowPrice());
    }
}
