using UnityEngine;

public class DataResetter : MonoBehaviour
{
    void Start()
    {
        DayTimeTimer.Instance.ResetTimer();
        DayTimeTimer.Instance.ActivateTimer();

        MoneyManager.Instance.RefreshMoneyInfo();
    }
}
