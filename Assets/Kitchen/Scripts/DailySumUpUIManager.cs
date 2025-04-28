using UnityEngine;
using TMPro;

public class DailySumUpUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI originalCashAmountText;
    [SerializeField] private TextMeshProUGUI earnedCashText;
    [SerializeField] private TextMeshProUGUI totalCashText;

    private void Start()
    {
        DayTimeTimer.Instance.OnDayEnd += OpenSumUpUI;
        UpdateCashAmountText();
    }

    private void OnDisable()
    {
        DayTimeTimer.Instance.OnDayEnd -= OpenSumUpUI;
    }

    public void UpdateCashAmountText()
    {
        originalCashAmountText.text = MoneyManager.Instance.OriginalMoney.ToString();
        earnedCashText.text = "+ " + MoneyManager.Instance.EarnedMoney;
        totalCashText.text = MoneyManager.Instance.TotalMoney.ToString();
    }

    public void OpenSumUpUI()
    {
        GetComponent<Animator>().SetTrigger("PopUp");
    }
}
