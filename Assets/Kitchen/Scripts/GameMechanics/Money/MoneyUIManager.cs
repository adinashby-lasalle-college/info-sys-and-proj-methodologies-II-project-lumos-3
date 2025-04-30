using TMPro;
using UnityEngine;

public class MoneyUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    void Start()
    {
        MoneyManager.Instance.OnMoneyModified += UpdateUI;

        UpdateUI(MoneyManager.Instance.TotalMoney);
    }

    private void OnDisable()
    {
        MoneyManager.Instance.OnMoneyModified += UpdateUI;
    }

    private void UpdateUI(int money)
    {
        moneyText.text = money.ToString();
    }
}
