public class HighPriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        if (cookTime < PriceManager.Instance.GetHighPriceTimeLimit())
        {
            PriceManager.Instance.SetPrice(PriceManager.Instance.GetHighPrice());
        }
        else if (nextHandler)
        {
            nextHandler.HandleRequest(cookTime);
        }
    }
}
