using UnityEngine;

public abstract class PriceHandler : MonoBehaviour
{
    protected PriceHandler nextHandler;
    protected PriceManager priceManager;

    private void Start()
    {
        priceManager = FindObjectOfType<PriceManager>();
    }

    public void SetNext(PriceHandler priceHandler)
    {
        nextHandler = priceHandler;
    }

    public abstract void HandleRequest(float cookTime);
}
