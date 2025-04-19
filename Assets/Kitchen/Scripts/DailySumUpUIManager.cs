using UnityEngine;
using TMPro;

public class DailySumUpUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI originalCashAmountText;
    [SerializeField] private TextMeshProUGUI earnedCashText;
    [SerializeField] private TextMeshProUGUI totalCashText;

    private void OnEnable()
    {
        UpdateCashAmountText();
    }

    public void UpdateCashAmountText()
    {
        originalCashAmountText.text = MoneyManager.Instance.OriginalMoney.ToString();
        earnedCashText.text = "+ " + MoneyManager.Instance.EarnedMoney;
        totalCashText.text = MoneyManager.Instance.TotalMoney.ToString();
    }
}
