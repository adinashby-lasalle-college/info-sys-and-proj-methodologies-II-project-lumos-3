using UnityEngine;

public class DataResetter : MonoBehaviour
{
    private void Start()
    {
        DayTimeTimer.Instance.ResetTimer();
        DayTimeTimer.Instance.ActivateTimer();

        MoneyManager.Instance.RefreshMoneyInfo();
    }

    public void ResetGameData()
    {
        MoneyManager.Instance.ResetMoney();
        DayTimeTimer.Instance.ResetDay();
        DayTimeTimer.Instance.ResetTimer();
    }
}
