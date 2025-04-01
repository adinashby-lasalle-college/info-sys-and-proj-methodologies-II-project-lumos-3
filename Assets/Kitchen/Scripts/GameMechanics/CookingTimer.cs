using System;
using UnityEngine;

public class CookingTimer : MonoBehaviour
{
    public static CookingTimer Instance { get; private set; }

    private bool isTimerActive = false;

    public event Action OnCookingTimerStart;

    public float TimerTime { get; private set; } // Current timer time
    public float CookTime { get; private set; } // Total cook time
    public float TimerMax { get; private set; }

    private void Awake()
    {
        Instance = this;

        TimerMax = 35f;
    }

    private void FixedUpdate()
    {
        if (isTimerActive)
        {
            TimerTime += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;

        OnCookingTimerStart?.Invoke();
    }

    public void StopTimer()
    {
        isTimerActive = false;

        CookTime = TimerTime;
        TimerTime = 0f;
    }
}
