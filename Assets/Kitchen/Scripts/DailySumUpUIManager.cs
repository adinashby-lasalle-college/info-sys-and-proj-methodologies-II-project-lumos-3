using UnityEngine;
using TMPro;

public class DailySumUpUIManager : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;

    [SerializeField] private TextMeshProUGUI originalCashAmountText;
    [SerializeField] private TextMeshProUGUI earnedCashText;
    [SerializeField] private TextMeshProUGUI totalCashText;

    private void OnEnable()
    {
        UpdateCashAmountText();
    }

    public void UpdateCashAmountText()
    {
        originalCashAmountText.text = moneyManager.OriginalMoney + " $";
        earnedCashText.text = "+ " + moneyManager.EarnedMoney + " $";
        totalCashText.text = moneyManager.TotalMoney + " $";
    }
}
