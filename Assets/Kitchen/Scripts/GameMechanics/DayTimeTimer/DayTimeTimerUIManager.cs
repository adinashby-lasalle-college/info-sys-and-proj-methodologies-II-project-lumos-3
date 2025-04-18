using TMPro;
using UnityEngine;

public class DayTimeTimerUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI dayText;

    private void Start()
    {
        DayTimeTimer.Instance.OnTimeChanged += UpdateTimeText;
        DayTimeTimer.Instance.OnDayChanged += UpdateDayText;

        UpdateDayText(DayTimeTimer.Instance.CurrDay);
    }

    private void OnDisable()
    {
        DayTimeTimer.Instance.OnTimeChanged -= UpdateTimeText;
        DayTimeTimer.Instance.OnDayChanged -= UpdateDayText;
    }

    private void UpdateTimeText(int hour, int minute, string amPm)
    {
        if (minute == 0)
        {
            timeText.text = hour + ":00 " + amPm;
        }
        else
        {
            timeText.text = hour + ":" + minute + " " + amPm;
        }
    }

    private void UpdateDayText(int day)
    {
        dayText.text = "Day " + day;
    }
}
