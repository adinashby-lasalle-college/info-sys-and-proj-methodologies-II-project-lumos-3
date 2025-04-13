using System;
using UnityEngine;

public class CookingTimer : MonoBehaviour
{
    public static CookingTimer Instance { get; private set; }

    private bool isTimerActive = false;
    private float timerSpeed = 0.7f;

    public event Action OnCookingTimerStart;

    public float CookTime { get; private set; } // Current timer time
    public float TimerMax { get; private set; }

    private void Awake()
    {
        Instance = this;

        CookTime = 0f;
        TimerMax = 35f;
    }

    private void Start()
    {
        Bell.Instance.OnServed += StopTimer;
    }

    private void FixedUpdate()
    {
        if (isTimerActive)
        {
            CookTime += Time.deltaTime * timerSpeed;
        }
    }

    public void StartTimer()
    {
        isTimerActive = true;

        OnCookingTimerStart?.Invoke();
    }

    public void StopTimer(int price)
    {
        isTimerActive = false;
        CookTime = 0f;
    }
}
