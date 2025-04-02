public class MiddlePriceHandler : PriceHandler
{
    public override void HandleRequest(float cookTime)
    {
        if (cookTime < PriceManager.Instance.GetMiddlePriceTimeLimit())
        {
            PriceManager.Instance.SetPrice(PriceManager.Instance.GetMiddlePrice());
        }
        else if (nextHandler)
        {
            nextHandler.HandleRequest(cookTime);
        }
    }
}
