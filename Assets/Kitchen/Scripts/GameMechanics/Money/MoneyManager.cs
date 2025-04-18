using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    public int OriginalMoney { get; private set; }
    public int EarnedMoney { get; private set; } // money earned today
    public int TotalMoney { get; private set; }

    public event Action<int> OnMoneyModified;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        RefreshMoneyInfo();
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
    }

    public void RefreshMoneyInfo()
    {
        OriginalMoney = TotalMoney;
        EarnedMoney = 0;

        OnMoneyModified?.Invoke(TotalMoney);
    }
}
