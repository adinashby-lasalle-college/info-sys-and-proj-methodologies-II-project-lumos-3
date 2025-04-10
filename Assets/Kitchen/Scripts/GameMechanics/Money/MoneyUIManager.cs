using TMPro;
using UnityEngine;

public class MoneyUIManager : MonoBehaviour
{
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private TextMeshProUGUI moneyText;

    void Start()
    {
        moneyManager.OnMoneyModified += UpdateUI;
    }

    private void UpdateUI(int money)
    {
        moneyText.text = money.ToString();
    }
}
