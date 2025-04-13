using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int OriginalMoney { get; private set; }
    public int EarnedMoney { get; private set; } // money earned today
    public int TotalMoney { get; private set; }

    public event Action<int> OnMoneyModified;

    private void Start()
    {
        Bell.Instance.OnServed += AddMoney;

        OriginalMoney = TotalMoney;
        EarnedMoney = 0;
    }

    private void OnDisable()
    {
        Bell.Instance.OnServed -= AddMoney;
    }

    public void AddMoney(int amount)
    {
        TotalMoney += amount;
        EarnedMoney += amount;

        OnMoneyModified?.Invoke(TotalMoney);
    }

    public void Withdraw(int amount)
    {
        TotalMoney -= amount;

        if (TotalMoney < 0)
        {
            TotalMoney = 0;
        }

        OnMoneyModified?.Invoke(TotalMoney);
    }
}
