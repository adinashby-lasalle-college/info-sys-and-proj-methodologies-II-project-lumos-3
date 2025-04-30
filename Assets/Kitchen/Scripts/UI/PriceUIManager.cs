using TMPro;
using UnityEngine;

public class PriceUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI basePriceText;
    [SerializeField] private TextMeshProUGUI additionalPriceText;
    [SerializeField] private Animator animator;
    [SerializeField] private PriceManager priceManager;

    private void Start()
    {
        priceManager.OnPriceCalculated += UpdateUI;
    }

    private void OnDisable()
    {
        priceManager.OnPriceCalculated -= UpdateUI;
    }

    public void UpdateUI(int basePrice, int addPrice)
    {
        basePriceText.text = "+ " + basePrice;
        additionalPriceText.text = "+" + addPrice;

        animator.SetTrigger("Rise");
    }
}
