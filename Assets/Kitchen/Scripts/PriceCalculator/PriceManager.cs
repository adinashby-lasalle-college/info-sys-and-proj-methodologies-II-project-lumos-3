using System;
using UnityEngine;

public class PriceManager : MonoBehaviour
{
    [SerializeField] RecipeManager recipeManager;
    [SerializeField] CookingTimer cookingTimer;

    private PriceHandler highPriceHandler;
    private PriceHandler middlePriceHandler;
    private PriceHandler lowPriceHandler;

    private float highPriceTimeLimit = 15f;
    private float middlePriceTimeLimit = 30f;

    private int highPrice = 15;
    private int middlePrice = 10;
    private int lowPrice = 5;

    private int price; // Price based on cooking time

    private void Start()
    {
        highPriceHandler = GetComponent<HighPriceHandler>();
        middlePriceHandler = GetComponent<MiddlePriceHandler>();
        lowPriceHandler = GetComponent<LowPriceHandler>();

        highPriceHandler.SetNext(middlePriceHandler);
        middlePriceHandler.SetNext(lowPriceHandler);
    }

    public int CalculatePrice(float cookTime)
    {
        highPriceHandler.HandleRequest(cookTime);
        int totalPrice = price + recipeManager.CurrRecipe.additionalPrice;

        return totalPrice;
    }

    public void SetPrice(int price)
    {
        this.price = price;
    }

    public float GetHighPriceTimeLimit()
    {
        return highPriceTimeLimit;
    }

    public float GetMiddlePriceTimeLimit()
    {
        return middlePriceTimeLimit;
    }

    public int GetHighPrice()
    {
        return highPrice;
    }

    public int GetMiddlePrice()
    {
        return middlePrice;
    }

    public int GetLowPrice()
    {
        return lowPrice;
    }
}
