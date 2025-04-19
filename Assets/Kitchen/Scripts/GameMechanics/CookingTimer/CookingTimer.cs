using System;
using UnityEngine;

public class CookingTimer : MonoBehaviour
{
    [SerializeField] private Bell bell;

    private bool isTimerActive = false;
    private float timerSpeed = 0.7f;

    public event Action OnCookingTimerStart;

    public float CookTime { get; private set; } // Current timer time
    public float TimerMax { get; private set; }

    private void Start()
    {
        CookTime = 0f;
        TimerMax = 35f;

        bell.OnServed += StopTimer;
    }

    private void OnDisable()
    {
        bell.OnServed -= StopTimer;
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

    public void StopTimer()
    {
        isTimerActive = false;
        CookTime = 0f;
    }
}
