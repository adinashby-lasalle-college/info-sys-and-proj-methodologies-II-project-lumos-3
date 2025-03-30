using UnityEngine;

public abstract class PriceHandler : MonoBehaviour
{
    protected PriceHandler nextHandler;

    public void SetNext(PriceHandler priceHandler)
    {
        nextHandler = priceHandler;
    }

    public abstract void HandleRequest(float cookTime);
}
