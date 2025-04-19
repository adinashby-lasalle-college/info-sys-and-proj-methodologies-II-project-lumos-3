using UnityEngine;

public class DataResetor : MonoBehaviour
{
    void Start()
    {
        DayTimeTimer.Instance.ResetTimer();
        DayTimeTimer.Instance.ActivateTimer();

        MoneyManager.Instance.RefreshMoneyInfo();
    }
}
