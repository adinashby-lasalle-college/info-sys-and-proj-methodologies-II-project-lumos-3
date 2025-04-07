using System;
using UnityEngine;

public class DayTimeTimer : MonoBehaviour
{
    private int startHour = 9;
    private int endHour = 10; // PM
    private float timer;
    private float timeForMinuteIncreasement = 1f;
    private string amPm = "AM";
    public event Action<int, int, string> OnTimeChanged;

    private int currHour;
    private int currMinute;

    private void Start()
    {
        currHour = startHour;
        currMinute = 0;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= timeForMinuteIncreasement)
        {
            currMinute += 10;
            timer = 0;

            if (currMinute >= 60)
            {
                currHour++;
                currMinute = 0;

                if (currHour == 12)
                {
                    amPm = "PM";
                }

                if (currHour == 13)
                {
                    currHour = 1;
                }

                if (currHour >= endHour && amPm == "PM")
                {
                    // * turn on the summary scene
                    Debug.Log("daytime ends");
                }
            }

            OnTimeChanged?.Invoke(currHour, currMinute, amPm);
        }
    }
}
