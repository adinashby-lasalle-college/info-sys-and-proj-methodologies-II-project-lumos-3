using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int CurrMoney { get; private set; }

    public event Action<int> OnMoneyModified;

    private void Start()
    {
        Bell.Instance.OnServed += AddMoney;
    }

    public void AddMoney(int amount)
    {
        CurrMoney += amount;

        OnMoneyModified?.Invoke(CurrMoney);
    }

    public void Withdraw(int amount)
    {
        CurrMoney -= amount;

        if (CurrMoney < 0)
        {
            CurrMoney = 0;
        }

        OnMoneyModified?.Invoke(CurrMoney);
    }
}
