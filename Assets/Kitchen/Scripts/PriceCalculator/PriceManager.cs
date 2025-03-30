using UnityEngine;

public class PriceManager : MonoBehaviour
{
    public static PriceManager Instance { get; private set; }

    private PriceHandler highPriceHandler;
    private PriceHandler middlePriceHandler;
    private PriceHandler lowPriceHandler;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        highPriceHandler = GetComponentInChildren<HighPriceHandler>();
        middlePriceHandler = GetComponentInChildren<MiddlePriceHandler>();
        lowPriceHandler = GetComponentInChildren<LowPriceHandler>();

        highPriceHandler.SetNext(middlePriceHandler);
        middlePriceHandler.SetNext(lowPriceHandler);
    }

    public void CalculatePrice(float cookTime)
    {
        highPriceHandler.HandleRequest(cookTime);
    }
}
