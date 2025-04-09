using TMPro;
using UnityEngine;

public class DayTimeTimerUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] DayTimeTimer dayTimeTimer;

    private void Start()
    {
        dayTimeTimer.OnTimeChanged += UpdateTimeText;
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
}
